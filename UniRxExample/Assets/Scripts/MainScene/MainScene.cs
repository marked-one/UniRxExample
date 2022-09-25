using System;
using UniRx;
using UniRxExample.MainScene.IntroLoading;
using UniRxExample.MainScene.TransitionScreen;
using Zenject;

namespace UniRxExample.MainScene
{
    public class MainScene : IScene
    {
        IIntroLoadingModel _introLoader;
        ITransition _transition;
        ISceneUnloader _sceneUnloader;
        ISceneLoader _sceneLoader;

        CompositeDisposable _disposables = new CompositeDisposable();

        [Inject]
        public MainScene(IIntroLoadingModel introLoader, ITransition transition,
                         ISceneUnloader sceneUnloader, ISceneLoader sceneLoader)
        {
            if (introLoader == null)
                throw new ArgumentNullException(nameof(introLoader));

            if (transition == null)
                throw new ArgumentNullException(nameof(transition));

            if (sceneUnloader == null)
                throw new ArgumentNullException(nameof(sceneUnloader));

            if (sceneLoader == null)
                throw new ArgumentNullException(nameof(sceneLoader));

            _introLoader = introLoader;
            _transition = transition;
            _sceneUnloader = sceneUnloader;
            _sceneLoader = sceneLoader;
        }

        public void OnStart() => _introLoader.Load()
                                             .ToObservable()
                                             .ObserveOnMainThread() // Looks like observables made from .Net tasks run in threads
                                             .Subscribe(_ =>
                                             {
                                                // Small delay to make completed progress bar visible on screen.
                                                 Observable.Timer(TimeSpan.FromSeconds(0.2)).Subscribe(_ => 
                                                 {
                                                    _disposables.Dispose();
                                                    _transition.Start(_sceneUnloader, _sceneLoader);
                                                 })
                                                 .AddTo(_disposables);
                                             })
                                             .AddTo(_disposables);
    }
}