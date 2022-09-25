using System;
using UniRx;
using Zenject;

namespace UniRxExample.MainScene.Transition
{
    public class SetActiveViewModel
    {
        public IReadOnlyReactiveProperty<bool> IsActive { get; }

        [Inject]
        public SetActiveViewModel(IActive model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            IsActive = model.ObserveEveryValueChanged(x => x.IsActive).ToReactiveProperty<bool>();
        }
    }
}
