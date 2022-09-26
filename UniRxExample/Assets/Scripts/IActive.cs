using UniRx;

namespace UniRxExample
{
    public interface IActive
    {
        ReactiveProperty<bool> IsActive { get; }
    }
}
