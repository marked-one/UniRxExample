using UniRx;

namespace UniRxExample
{
    public interface IClickable
    {
        ReactiveProperty<bool> Clicked { get; }
        void Click();
    }
}