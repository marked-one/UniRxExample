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
            // FAKE: loading imitation
            Progress.Value = 0f;
            await Observable.Timer(TimeSpan.FromSeconds(0.1));	
            Progress.Value = 0.1f;
            await Observable.Timer(TimeSpan.FromSeconds(0.7));	
            Progress.Value = 0.7f;
            await Observable.Timer(TimeSpan.FromSeconds(0.3));	
            Progress.Value = 1f;
        }
    }
}