using System;
using System.Threading.Tasks;

namespace UniRxExample.MainScene.IntroLoading
{
    public interface IIntroLoadingModel
    {
        Task Load();
    }

    public class IntroLoadingModel : IIntroLoadingModel, IProgress
    {
        public float Progress { get; private set; } = 0f;

        public async Task Load()
        {
            // FAKE: loading imitation

            Progress = 0f;
            await Task.Delay(TimeSpan.FromSeconds(0.1));
            Progress = 0.1f;
            await Task.Delay(TimeSpan.FromSeconds(0.7));
            Progress = 0.7f;
            await Task.Delay(TimeSpan.FromSeconds(0.3));
            Progress = 1f;
        }
    }
}