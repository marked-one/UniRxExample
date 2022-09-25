using UniRxExample.MainScene.IntroLoading;
using UniRxExample.MainScene.Transition;
using UnityEngine.SceneManagement;
using Zenject;
using UniRx;
using System;

namespace UniRxExample.MainScene
{
    public class MainScene : IScene
    {
        IIntroLoadingModel _introLoader;
        ISceneUnloader _sceneUnloader;
        ITransitionModel _transition;
        string _nextScene;

        CompositeDisposable _disposables = new CompositeDisposable();

        [Inject]
        public MainScene(IIntroLoadingModel introLoader, ISceneUnloader sceneUnloader, ITransitionModel transition, string nextScene)
        {
            if (introLoader == null)
                throw new ArgumentNullException(nameof(introLoader));

            if (sceneUnloader == null)
                throw new ArgumentNullException(nameof(sceneUnloader));

            if (transition == null)
                throw new ArgumentNullException(nameof(transition));

            if (string.IsNullOrEmpty(nextScene))
                throw new ArgumentException("Invalid next scene name", nameof(nextScene));

            _introLoader = introLoader;
            _sceneUnloader = sceneUnloader;
            _transition = transition;
            _nextScene = nextScene;
        }

        public void OnStart()
        {
            // I personally would prefer UniTask here since loading here is about async operations
            // and not about data. But let's implement this through observables for demonstration purposes.

            LoadIntro(LoadNextScene);

            void LoadIntro(Action completed)
            {
                var introLoading = _introLoader.Load().ToObservable().ObserveOnMainThread(); // Looks like observables made from .Net tasks run in threads
                introLoading.Subscribe(_ => 
                {
                    _transition.Activate();
                    _sceneUnloader.Unload();
                    completed?.Invoke();
                })
                .AddTo(_disposables);
            }

            void LoadNextScene()
            {
                var sceneLoading = SceneManager.LoadSceneAsync(_nextScene, LoadSceneMode.Additive).ToObservable();
                var sceneLoadingDelay = Observable.Timer(TimeSpan.FromSeconds(1.5)); // It looks weird when loading screen disappears too early.
                var sceneLoadingWithDelay = Observable.CombineLatest<float, long, Unit>(sceneLoading, sceneLoadingDelay, (_, __) => Unit.Default);
                sceneLoadingWithDelay.Subscribe(_ => 
                {
                    _transition.Deactivate();
                    _disposables.Dispose();
                })
                .AddTo(_disposables);
            }
        }
    }
}