using System;

namespace sample.Interfaces
{
    public interface IGridCellAnimationHandler
    {
        void PlayCorrectAnimation(Action onComplete);
        void PlayIncorrectAnimation(Action onComplete);
        void Show(Action onComplete);
    }
}
