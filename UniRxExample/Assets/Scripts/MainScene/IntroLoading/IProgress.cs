using UniRx;

namespace UniRxExample.MainScene.IntroLoading
{
    public interface IProgress
    {
        ReactiveProperty<float> Progress { get; }
    }
}