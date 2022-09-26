using System;
using UniRx;
using Zenject;

namespace UniRxExample
{
    public class ButtonViewModel
    {
        public ReactiveCommand Click { get; private set; }

        [Inject]
        public ButtonViewModel(IClickable model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            Click = model.Clicked.Select(clicked => !clicked).ToReactiveCommand();
            Click.Subscribe(_ => model.Click());
        }
    }
}
