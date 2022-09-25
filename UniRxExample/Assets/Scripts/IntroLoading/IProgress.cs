using UniRx;

namespace UniRxExample.IntroLoading
{
    public interface IProgress
    {
        ReactiveProperty<float> Progress { get; }
    }
}