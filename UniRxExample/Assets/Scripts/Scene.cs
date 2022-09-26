using System;
using UniRx;
using UniRxExample.MainScene.TransitionScreen;

namespace UniRxExample
{
    public abstract class Scene : IScene
    {
        ITransition _transition;
        ISceneUnloader _sceneUnloader;
        ISceneLoader _sceneLoader;

        CompositeDisposable _disposables = new ();

        public Scene(ITransition transition, ISceneUnloader sceneUnloader, ISceneLoader sceneLoader)
        {
            if (transition == null)
                throw new ArgumentNullException(nameof(transition));

            if (sceneUnloader == null)
                throw new ArgumentNullException(nameof(sceneUnloader));

            if (sceneLoader == null)
                throw new ArgumentNullException(nameof(sceneLoader));

            _transition = transition;
            _sceneUnloader = sceneUnloader;
            _sceneLoader = sceneLoader;
        }

        public void Start() => OnStart(_transition, _sceneUnloader, _sceneLoader, _disposables);

        protected abstract void OnStart(ITransition transition, ISceneUnloader sceneUnloader,
                                        ISceneLoader sceneLoader, CompositeDisposable disposables);
    }
}