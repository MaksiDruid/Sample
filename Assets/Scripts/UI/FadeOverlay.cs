using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

namespace sample.UI
{
    public class FadeOverlay : MonoBehaviour
    {
        [SerializeField] private Image _fadeImage;
        [SerializeField] private float _fadeValue = 0.6f;
        [SerializeField] private float _fadeDuration = 1f;

        public void FadeIn()
        {
            _fadeImage.DOFade(_fadeValue, _fadeDuration);
        }

        public void ShowLoadingScreen(Action afterFadeAction)
        {
            _fadeImage.DOFade(1, _fadeDuration - _fadeValue)
                .OnComplete(() =>
                {
                    afterFadeAction?.Invoke();
                    _fadeImage.DOFade(0, _fadeDuration);
                });
        }
    }
}
