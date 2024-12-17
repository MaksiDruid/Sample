using System;

namespace sample.Interfaces
{
    public interface ILevelHandler
    {
        void StartGame();
        void RestartGame();
        event Action OnGameEnd;
        event Action<string> OnNextLevel;
    }
}
