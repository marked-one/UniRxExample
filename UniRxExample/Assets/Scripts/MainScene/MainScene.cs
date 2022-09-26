using System;
using UniRx;
using UniRxExample.MainScene.IntroLoading;
using UniRxExample.MainScene.TransitionScreen;
using Zenject;

namespace UniRxExample.MainScene
{
    public class MainScene : Scene
    {
        IIntroLoader _introLoader;

        [Inject]
        public MainScene(IIntroLoader introLoader, ITransition transition,
                         ISceneUnloader sceneUnloader, ISceneLoader sceneLoader)
            : base(transition, sceneUnloader, sceneLoader)
        {
            if (introLoader == null)
                throw new ArgumentNullException(nameof(introLoader));

            _introLoader = introLoader;
        }

        protected override void OnStart(ITransition transition, ISceneUnloader sceneUnloader,
                                        ISceneLoader sceneLoader, CompositeDisposable disposables)
        {
            _introLoader.Load()
                        .ToObservable()
                        .ObserveOnMainThread() // Looks like observables made from .Net tasks run in threads
                        .Subscribe(_ =>
                        {
                            // Small delay to make completed progress bar visible on screen.
                            Observable.Timer(TimeSpan.FromSeconds(0.2)).Subscribe(_ => 
                            {
                                disposables.Dispose();
                                transition.Start(sceneUnloader, sceneLoader);
                            })
                            .AddTo(disposables);
                        })
                        .AddTo(disposables);
        }
    }
}