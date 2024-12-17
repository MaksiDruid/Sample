using sample.SO;
using System.Collections.Generic;

namespace sample.Interfaces
{
    public interface ICorrectValueSelector
    {
        string ChooseCorrectValue(List<CellData> availableData, HashSet<string> usedValues);
    }
}
