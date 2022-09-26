using System;
using UniRx;
using Zenject;

namespace UniRxExample.TransitionScreen
{
    public class SetActiveViewModel
    {
        public IReadOnlyReactiveProperty<bool> IsActive { get; }

        [Inject]
        public SetActiveViewModel(IActive model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            IsActive = model.ObserveEveryValueChanged(model => model.IsActive).ToReactiveProperty<bool>();
        }
    }
}
