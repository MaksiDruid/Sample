using UnityEngine;
using DG.Tweening;
using System;
using sample.VFX;
using VContainer;
using sample.Interfaces;

namespace sample.Grid
{
    public class CellAnimator : MonoBehaviour, IGridCellAnimationHandler
    {
        [SerializeField] private Transform _cell;
        [SerializeField] private float _shakeStrength = 0.3f;
        [SerializeField] private int _shakeVibrato = 10;
        [SerializeField] private float _bounceDuration = 0.5f;

        private ParticlesController _particles;
        private Vector3 _originSize;

        [Inject]
        public void Construct(ParticlesController particles)
        {
            _particles = particles;
        }

        public void Initialize()
        {
            _originSize = transform.localScale;
        }

        public void PlayCorrectAnimation(Action onComplete = null)
        {
            transform.DOScale(_originSize * 1.2f, _bounceDuration)
            .SetEase(Ease.OutBounce)
            .OnComplete(() =>
            {
                transform.DOScale(_originSize, _bounceDuration).SetEase(Ease.OutBounce)
                    .OnComplete(() =>
                    {
                        onComplete?.Invoke();
                    });
            });

            _particles.PlayStars(transform);
        }

        public void PlayIncorrectAnimation(Action onComplete = null)
        {
            transform.DOShakePosition(
               duration: _bounceDuration,
               strength: new Vector3(_shakeStrength, 0, 0),
               vibrato: _shakeVibrato,
               randomness: 0
               ).SetEase(Ease.OutBounce)
               .OnComplete(()=>
               {
                   onComplete?.Invoke();
               });
        }

        public void Show(Action onComplete = null)
        {
            _cell.localScale = Vector3.zero;
            _cell.gameObject.SetActive(true);
            _cell.DOScale(Vector3.one, _bounceDuration)
                .SetEase(Ease.OutBounce)
                .OnComplete(() =>
                {
                    onComplete?.Invoke();
                });
        }
    }
}
