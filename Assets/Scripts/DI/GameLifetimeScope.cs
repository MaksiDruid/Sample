using sample.Grid;
using sample.Levels;
using sample.SO;
using sample.UI;
using sample.VFX;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace sample.DI
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private Cell _cellPrefab;
        [SerializeField] private LevelsData _levelsData;
        [SerializeField] private SeveralCellKits _severalCellKits;
        [SerializeField] private GridGenerator _gridGenerator;
        [SerializeField] private ParticlesController _particlesController;
        [SerializeField] private FadeOverlay _fadeOverlay;
        [SerializeField] private UIButton _restartButton;
        [SerializeField] private TaskDisplay _taskDisplay;
        [SerializeField] private GameStateHandler _gameStateHandler;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_cellPrefab);
            builder.RegisterInstance(_levelsData);
            builder.RegisterInstance(_severalCellKits);

            builder.RegisterComponent(_particlesController).AsSelf();
            builder.RegisterComponent(_fadeOverlay).AsSelf();
            builder.RegisterComponent(_restartButton).AsSelf();
            builder.RegisterComponent(_taskDisplay).AsSelf();

            builder.Register<UIManager>(Lifetime.Singleton).AsSelf();
            builder.Register<CellFactory>(Lifetime.Singleton).AsSelf();
            builder.Register<CorrectValueSelector>(Lifetime.Singleton).AsSelf();

            builder.RegisterComponent(_gridGenerator).AsSelf();

            builder.Register<LevelChanger>(Lifetime.Singleton).AsSelf();

            builder.RegisterComponent(_gameStateHandler).AsSelf();
        }
    }
}