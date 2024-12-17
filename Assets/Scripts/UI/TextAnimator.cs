using DG.Tweening;
using TMPro;

namespace sample.UI
{
    public class TextAnimator
    {
        private readonly TextMeshProUGUI _text;
        private readonly float _fadeDuration;

        public TextAnimator(TextMeshProUGUI text, float fadeDuration)
        {
            _text = text;
            _fadeDuration = fadeDuration;

            _text.DOFade(0, 0); 
            _text.gameObject.SetActive(true);
        }

        public void FadeIn()
        {
            _text.DOFade(1, _fadeDuration);
        }

        public void FadeOut()
        {
            _text.DOFade(0, _fadeDuration);
        }
    }
}
