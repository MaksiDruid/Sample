using System;
using UnityEngine.Events;

namespace sample.UI
{
    public class UIManager
    {
        private readonly FadeOverlay _fadeOverlay;
        private readonly UIButton _restartButton;

        public UIManager(FadeOverlay fadeOverlay, UIButton restartButton)
        {
            _fadeOverlay = fadeOverlay;
            _restartButton = restartButton;
        }

        public void ShowRestartButton(UnityAction onClick)
        {
            _restartButton.Initialize(onClick);
            _restartButton.Show();
        }

        public void HideRestartButton()
        {
            _restartButton.Hide();
        }

        public void ShowLoadingScreen(Action onLoadingComplete)
        {
            _fadeOverlay.ShowLoadingScreen(onLoadingComplete);
        }

        public void FadeInOverlay()
        {
            _fadeOverlay.FadeIn();
        }
    }
}
