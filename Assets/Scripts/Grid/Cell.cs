using UnityEngine;
using sample.SO;
using System;
using VContainer;

namespace sample.Grid
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _valueSprite;
        [SerializeField] private CellAnimator _animator;
        [SerializeField] private Collider2D _collider;

        private Func<string, bool> _onCellClicked;
        private string _currentValue;
        private IObjectResolver _diContainer;

        private Action _onCorrectComplete;

        [Inject]
        public void Construct(IObjectResolver container)
        {
            _diContainer = container;
        }

        public bool Interactable
        {
            get => _collider.enabled;
            set => _collider.enabled = value;
        }

        public void Initialize(CellData cellData, Func<string, bool> onClickAction, Action onRightAnswer)
        {
            _currentValue = cellData.Value;
            _onCellClicked = onClickAction;
            _onCorrectComplete = onRightAnswer;
            _valueSprite.sprite = cellData.Sprite;
            _valueSprite.transform.rotation = cellData.ShouldRotate ?
                Quaternion.Euler(0, 0, cellData.RotationAngle) : Quaternion.identity;
            
            _diContainer.Inject(_animator);

            _animator.Initialize();
            _animator.Show(() => Interactable = true);
        }

        private void OnMouseDown()
        {
            bool isCorrect = _onCellClicked.Invoke(_currentValue);

            if (isCorrect)
            {
                _animator.PlayCorrectAnimation(_onCorrectComplete);
            }
            else
            {
                _animator.PlayIncorrectAnimation();
            }
        }

    }
}