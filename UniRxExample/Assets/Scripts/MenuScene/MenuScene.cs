using System;
using UniRx;
using UniRxExample.MainScene.TransitionScreen;
using Zenject;

namespace UniRxExample.MenuScene
{
    public class MenuScene : IScene
    {
        ITransition _transition;
        ISceneUnloader _sceneUnloader;
        ISceneLoader _sceneLoader;
        IPlayButton _playButton;

        CompositeDisposable _disposables = new ();

        [Inject] 
        public MenuScene(ITransition transition, ISceneUnloader sceneUnloader,
                         ISceneLoader sceneLoader, IPlayButton playButton)
        {
            if (transition == null)
                throw new ArgumentNullException(nameof(transition));

            if (sceneUnloader == null)
                throw new ArgumentNullException(nameof(sceneUnloader));

            if (sceneLoader == null)
                throw new ArgumentNullException(nameof(sceneLoader));

            if (playButton == null)
                throw new ArgumentNullException(nameof(playButton));

            _transition = transition;
            _sceneUnloader = sceneUnloader;
            _sceneLoader = sceneLoader;
            _playButton = playButton;
        }

        public void OnStart()
        {
            _playButton.ObserveEveryValueChanged(button => button.Clicked).Where(clicked => clicked).Subscribe(_ => 
            {
                _disposables.Dispose();
                _transition.Start(_sceneUnloader, _sceneLoader);
            })
            .AddTo(_disposables);
        }
    }
}