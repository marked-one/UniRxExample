using System;
using System.Threading.Tasks;
using UniRx;

namespace UniRxExample.IntroLoading
{
    public interface IIntroLoader
    {
        Task Load();
    }

    public class IntroLoader : IIntroLoader, IProgress
    {
        public ReactiveProperty<float> Progress { get; private set; } = new (0f);

        public async Task Load()
        {
            // FAKE loading
            Progress.Value = 0f;
            await Observable.Timer(TimeSpan.FromSeconds(0.1));	
            Progress.Value = 0.2f;
            await Observable.Timer(TimeSpan.FromSeconds(0.7));	
            Progress.Value = 0.8f;
            await Observable.Timer(TimeSpan.FromSeconds(0.3));	
            Progress.Value = 1f;
        }
    }
}