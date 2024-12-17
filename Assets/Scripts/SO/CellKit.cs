using UnityEngine;

namespace sample.SO
{
    [CreateAssetMenu(fileName = "CellKit", menuName = "Game/CellKit")]
    public class CellKit : ScriptableObject
    {
        [SerializeField] private CellData[] _cellData;

        public CellData[] CellData => _cellData;
    }

    [System.Serializable]
    public class CellData
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private string _value;
        [SerializeField] private bool _shouldRotate = false;
        [SerializeField, Range(-180, 180)] private float _rotationAngle = 0f;

        public Sprite Sprite => _sprite;
        public string Value => _value;
        public bool ShouldRotate => _shouldRotate;
        public float RotationAngle => _shouldRotate ? _rotationAngle : 0f;
    }
}