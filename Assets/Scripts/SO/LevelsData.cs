using UnityEngine;

namespace sample.SO
{
    [CreateAssetMenu(fileName = "LevelsData", menuName = "Game/LevelData")]
    public class LevelsData : ScriptableObject
    {
        [SerializeField] private Level[] _levels;
        private int _maxCells;
        public Level[] Levels => _levels;
        public int MaxCells
        {
            get
            {
                if (_maxCells == 0)
                {
                    foreach (var level in _levels)
                    {
                        int cells = level.Rows * level.Columns;
                        if (cells > _maxCells)
                        {
                            _maxCells = cells;
                        }
                    }
                }
                return _maxCells;
            }
        }
    }

    [System.Serializable]
    public class Level
    {
        [SerializeField] private int _rows;
        [SerializeField] private int _columns;

        public int Rows => _rows;
        public int Columns => _columns;
    }
}
