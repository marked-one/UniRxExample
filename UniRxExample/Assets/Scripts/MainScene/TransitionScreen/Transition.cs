using System;
using UniRx;

namespace UniRxExample.MainScene.TransitionScreen
{
    public interface ITransition
    {
        void Start(ISceneUnloader unloader, ISceneLoader loader);
    }

    public class Transition : ITransition, IActive
    {
        CompositeDisposable _disposables = new ();

        public ReactiveProperty<bool> IsActive { get; private set; } = new(false);

        public void Start(ISceneUnloader unloader, ISceneLoader loader)
        {
            if (unloader == null)
                throw new ArgumentNullException(nameof(unloader));

            if (loader == null)
                throw new ArgumentNullException(nameof(loader));

            IsActive.Value = true;

            var unloading = unloader.Unload();
            var sceneLoading = loader.Load();
            var loading = unloading.Concat(sceneLoading);
            var minTransitionTime = Observable.Timer(TimeSpan.FromSeconds(2.0)); // It looks weird when loading screen disappears fast.
            var transition = Observable.CombineLatest<float, long, Unit>(loading, minTransitionTime, (_, __) => Unit.Default);
            transition.Subscribe(_ => 
            {
                IsActive.Value = false;
                _disposables.Clear(); // Reusable
            })
            .AddTo(_disposables);
        }
    }
}
