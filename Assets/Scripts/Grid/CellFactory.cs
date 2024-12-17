using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace sample.Grid
{
    public class CellFactory
    {
        private readonly Cell _cellPrefab;
        private readonly IObjectResolver _diContainer;

        public CellFactory(IObjectResolver diContainer, Cell cellPrefab)
        {
            _diContainer = diContainer;
            _cellPrefab = cellPrefab;
        }

        public List<Cell> CreateCells(Transform parent, int count)
        {
            var cells = new List<Cell>();
            for (int i = 0; i < count; i++)
            {
                Cell newCell = Object.Instantiate(_cellPrefab, parent);
                newCell.gameObject.SetActive(false);
                _diContainer.Inject(newCell);
                cells.Add(newCell);
            }
            return cells;
        }
    }

}
