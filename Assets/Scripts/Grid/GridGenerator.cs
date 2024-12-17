using System.Collections.Generic;
using UnityEngine;
using sample.SO;
using System;
using Random = UnityEngine.Random;
using System.Linq;
using VContainer;

namespace sample.Grid
{
    public class GridGenerator : MonoBehaviour
    {
        [SerializeField] private GridLayoutController _gridLayoutController;
        private CellFactory _cellFactory;
        private List<Cell> _cells;
        private CorrectValueSelector _correctValueSelector;

        [Inject]
        public void Construct(CellFactory cellFactory, CorrectValueSelector correctValueSelector)
        {
            _cellFactory = cellFactory;
            _correctValueSelector = correctValueSelector;
        }

        public void GenerateGrid(int maxCellCount)
        {
            if (_cells != null) return;
            _cells = _cellFactory.CreateCells(transform, maxCellCount);
        }

        public void Initialize(Level level, CellData[] ñellData, HashSet<string> usedValues, Action onRightAnswer, out string correctValue)
        {
            int totalCells = level.Rows * level.Columns;

            List<CellData> availableData = SelectRandomCells(ñellData, totalCells);

            LayoutGrid(level, totalCells);

            InitializeCells(availableData, totalCells, onRightAnswer);

            correctValue = _correctValueSelector.ChooseCorrectValue(availableData, usedValues);
        }

        public void DisableCells()
        {
            foreach (var cell in _cells)
            {
                cell.Interactable = false;
            }
        }

        private List<CellData> SelectRandomCells(CellData[] ñellData, int totalCells)
        {
            return ñellData
                .OrderBy(_ => Random.value)
                .Take(totalCells)
                .ToList();
        }

        private void InitializeCells(List<CellData> availableData, int totalCells, Action onRightAnswer)
        {
            for (int i = 0; i < _cells.Count; i++)
            {
                var cell = _cells[i];
                if (i < totalCells)
                {
                    cell.Initialize(availableData[i], OnCellClicked, onRightAnswer);
                }
                else
                {
                    cell.gameObject.SetActive(false);
                }
            }
        }

        private void LayoutGrid(Level level, int totalCells)
        {
            _gridLayoutController.PositionCells(_cells.Take(totalCells).Select(c => c.transform).ToArray(), level.Rows, level.Columns);
        }

        private bool OnCellClicked(string cellValue)
        {
            bool correct = cellValue == _correctValueSelector.CorrectValue;
            if (correct) DisableCells();
            return correct;
        }
    }
}
