using UniRx;

namespace UniRxExample.TransitionScreen
{
    public interface IActive
    {
        ReactiveProperty<bool> Active { get; }
    }
}
