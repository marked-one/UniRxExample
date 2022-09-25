using System;
using UniRx;
using Zenject;

namespace UniRxExample.TransitionScreen
{
    public class SetActiveViewModel
    {
        public ReactiveProperty<bool> Active { get; }

        [Inject]
        public SetActiveViewModel(IActive model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            Active = model.Active;
        }
    }
}
