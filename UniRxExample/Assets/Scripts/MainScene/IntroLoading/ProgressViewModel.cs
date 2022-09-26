using System;
using UniRx;
using Zenject;

namespace UniRxExample.MainScene.IntroLoading
{
    public class ProgressViewModel
    {
        public IReadOnlyReactiveProperty<float> Progress { get; }

        [Inject]
        public ProgressViewModel(IProgress model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            Progress = model.Progress;
        }
    }
}
