using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using sample.SO;
using sample.Interfaces;

namespace sample.Grid
{
    public class CorrectValueSelector : ICorrectValueSelector
    {
        public string CorrectValue { get; private set; }

        public string ChooseCorrectValue(List<CellData> availableData, HashSet<string> usedValues)
        {
            List<CellData> uniqueAvailableData = availableData
                .Where(data => !usedValues.Contains(data.Value))
                .ToList();

            if (uniqueAvailableData.Count > 0)
            {
                CellData correctCellData = uniqueAvailableData[Random.Range(0, uniqueAvailableData.Count)];
                CorrectValue = correctCellData.Value;

                usedValues.Add(CorrectValue);
            }
            else
            {
                Debug.LogError("Unable to find unique data");
                CorrectValue = string.Empty;
            }

            return CorrectValue;
        }
    }
}
