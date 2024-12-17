using UnityEngine;

namespace sample.Grid
{
    public class GridLayoutController : MonoBehaviour
    {
        [SerializeField] private Vector2 _cellSize = new Vector2(1f, 1f);
        [SerializeField] private Vector2 _spacing = new Vector2(0.1f, 0.1f);

        public void PositionCells(Transform[] cells, int rows, int columns)
        {
            if (cells == null || cells.Length == 0)
            {
                Debug.LogError("No cells.");
                return;
            }

            if (rows * columns < cells.Length)
            {
                Debug.LogError("Not enough rows and columns.");
                return;
            }

            Vector3 startPosition = CalculateStartPosition(rows, columns);

            for (int i = 0; i < cells.Length; i++)
            {
                if (i >= rows * columns) break;

                int row = i / columns;
                int column = i % columns;

                Vector3 cellPosition = startPosition + new Vector3(
                    column * (_cellSize.x + _spacing.x),
                    -row * (_cellSize.y + _spacing.y), 0);

                cells[i].localPosition = cellPosition;
            }
        }

        private Vector3 CalculateStartPosition(int rows, int columns)
        {
            float gridWidth = columns * _cellSize.x + (columns - 1) * _spacing.x;
            float gridHeight = rows * _cellSize.y + (rows - 1) * _spacing.y;

            return new Vector3(-gridWidth / 2 + _cellSize.x / 2, gridHeight / 2 - _cellSize.y / 2, 0);
        }
    }
}
