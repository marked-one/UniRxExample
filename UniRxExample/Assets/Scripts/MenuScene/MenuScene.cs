using System;
using UniRx;
using UniRxExample.MainScene.TransitionScreen;
using Zenject;

namespace UniRxExample.MenuScene
{
    public class MenuScene : Scene
    {
        IPlayButton _playButton;

        [Inject] 
        public MenuScene(ITransition transition, ISceneUnloader sceneUnloader,
                         ISceneLoader sceneLoader, IPlayButton playButton)
            : base(transition, sceneUnloader, sceneLoader)
        {
            if (playButton == null)
                throw new ArgumentNullException(nameof(playButton));

            _playButton = playButton;
        }

        protected override void OnStart(ITransition transition, ISceneUnloader sceneUnloader,
                                        ISceneLoader sceneLoader, CompositeDisposable disposables)
        {
            _playButton.Clicked.Where(clicked => clicked).Subscribe(_ => 
            {
                disposables.Dispose();
                transition.Start(sceneUnloader, sceneLoader);
            })
            .AddTo(disposables);
        }
    }
}