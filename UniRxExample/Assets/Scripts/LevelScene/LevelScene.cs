using System;
using UniRx;
using UniRxExample.MainScene.TransitionScreen;
using Zenject;

namespace UniRxExample.LevelScene
{
    public class LevelScene : Scene
    {
        IBackButton _backButton;

        [Inject] 
        public LevelScene(ITransition transition, ISceneUnloader sceneUnloader,
                         ISceneLoader sceneLoader, IBackButton backButton)
            : base(transition, sceneUnloader, sceneLoader)
        {
            if (backButton == null)
                throw new ArgumentNullException(nameof(backButton));

            _backButton = backButton;
        }

        protected override void OnStart(ITransition transition, ISceneUnloader sceneUnloader,
                                        ISceneLoader sceneLoader, CompositeDisposable disposables)
        {
            _backButton.Clicked.Where(clicked => clicked).Subscribe(_ => 
            {
                disposables.Dispose();
                transition.Start(sceneUnloader, sceneLoader);
            })
            .AddTo(disposables);
        }
    }
}