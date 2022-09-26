using System;
using System.Threading.Tasks;
using UniRx;

namespace UniRxExample.MainScene.IntroLoading
{
    public interface IIntroLoader
    {
        Task Load();
    }

    public class IntroLoader : IIntroLoader, IProgress
    {
        public ReactiveProperty<float> Progress { get; private set; } = new(0f);

        public async Task Load()
        {
            // FAKE: async loading imitation

            Progress.Value = 0f;
            await Task.Delay(TimeSpan.FromSeconds(0.1));
            Progress.Value = 0.1f;
            await Task.Delay(TimeSpan.FromSeconds(0.7));
            Progress.Value = 0.7f;
            await Task.Delay(TimeSpan.FromSeconds(0.3));
            Progress.Value = 1f;
        }
    }
}