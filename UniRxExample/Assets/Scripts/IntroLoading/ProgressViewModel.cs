using System;
using UniRx;
using Zenject;

namespace UniRxExample.IntroLoading
{
    public class ProgressViewModel
    {
        public ReactiveProperty<float> Progress { get; }

        [Inject]
        public ProgressViewModel(IProgress model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            Progress = model.Progress;
        }
    }
}
