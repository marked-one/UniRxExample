using System;
using UniRx;
using Zenject;

namespace UniRxExample.MenuScene
{
    public class ButtonViewModel
    {
        IReadOnlyReactiveProperty<bool> Clicked { get; set; }
        public ReactiveCommand Click { get; private set; }

        [Inject]
        public ButtonViewModel(IClickable model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            Clicked = model.ObserveEveryValueChanged(model => model.Clicked).ToReactiveProperty<bool>();
            Click = Clicked.Select(clicked => !clicked).ToReactiveCommand();
            Click.Subscribe(_ => 
            {
                model.Click();
            });
        }
    }
}
