using sample.UI;
using UnityEngine;
using VContainer;

namespace sample.Levels
{
    public class GameStateHandler : MonoBehaviour
    {
        private TaskDisplay _taskDisplay;
        private LevelChanger _levelChanger;
        private UIManager _uiManager;

        [Inject]
        public void Construct(UIManager uiManager, TaskDisplay taskDisplay, LevelChanger levelChanger)
        {
            _taskDisplay = taskDisplay;
            _levelChanger = levelChanger;
            _uiManager = uiManager;
        }

        private void Start()
        {
            _levelChanger.OnNextLevel += OnNextLevel;
            _levelChanger.OnGameEnd += OnGameEnd;

            _levelChanger.StartGame();
        }

        private void OnDestroy()
        {
            _levelChanger.OnNextLevel -= OnNextLevel;
            _levelChanger.OnGameEnd -= OnGameEnd;
        }

        private void OnNextLevel(string value)
        {
            _taskDisplay.SetTask($"Find {value}");
        }

        private void OnGameEnd()
        {
            _uiManager.FadeInOverlay();
            _uiManager.ShowRestartButton(() =>
            {
                _uiManager.ShowLoadingScreen(_levelChanger.RestartGame);
            });
            _taskDisplay.Hide();
        }
    }
}
