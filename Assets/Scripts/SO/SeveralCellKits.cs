using UnityEngine;

namespace sample.SO
{
    [CreateAssetMenu(fileName = "SeveralCellKits", menuName = "Game/SeveralCellKits")]
    public class SeveralCellKits : ScriptableObject
    {
        [SerializeField] private CellKit[] _cellKits;

        public CellKit GetRandomCellKit()
        {
            return _cellKits[Random.Range(0, _cellKits.Length)];
        }
    }
}
