using UnityEngine;
using TMPro;

namespace sample.UI
{
    public class TaskDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _taskText;
        [SerializeField] private float _fadeDuration = 0.5f;

        private TextAnimator _textAnimator;

        public void SetTask(string taskDescription)
        {
            if (_textAnimator == null)
            {
                _textAnimator = new TextAnimator(_taskText, _fadeDuration);
            }

            _taskText.text = taskDescription;
            _textAnimator.FadeIn();
        }

        public void Hide()
        {
            _textAnimator.FadeOut();
        }
    }
}
