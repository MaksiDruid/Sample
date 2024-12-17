using System;
using System.Collections.Generic;
using sample.Grid;
using sample.Interfaces;
using sample.SO;

namespace sample.Levels
{
    public class LevelChanger : ILevelHandler
    {
        private readonly LevelsData _levelsData;
        private readonly SeveralCellKits _severalCellKits;
        private readonly GridGenerator _gridGenerator;
        private readonly HashSet<string> _usedValues = new HashSet<string>();
        private int _currentLevelIndex;
        private CellKit _currentCellKit;

        public event Action OnGameEnd;
        public event Action<string> OnNextLevel;

        public LevelChanger(LevelsData levelsData, SeveralCellKits severalCellKits, GridGenerator gridGenerator)
        {
            _levelsData = levelsData;
            _severalCellKits = severalCellKits;
            _gridGenerator = gridGenerator;
        }

        public void StartGame()
        {
            _gridGenerator.GenerateGrid(_levelsData.MaxCells);
            ResetGame();
        }

        public void RestartGame()
        {
            ResetGame();
        }

        private void ResetGame()
        {
            _currentLevelIndex = 0;
            _usedValues.Clear();
            LoadNextLevel();
        }

        private void LoadNextLevel()
        {
            if (_currentLevelIndex >= _levelsData.Levels.Length)
            {
                OnGameEnd?.Invoke();
                return;
            }

            SelectRandomCellKit();
            Level level = _levelsData.Levels[_currentLevelIndex];
            _gridGenerator.Initialize(level, _currentCellKit.CellData, _usedValues, LoadNextLevel, out string correctValue);

            OnNextLevel?.Invoke(correctValue);
            _currentLevelIndex++;
        }

        private void SelectRandomCellKit()
        {
            _currentCellKit = _severalCellKits.GetRandomCellKit();
        }
    }

}
