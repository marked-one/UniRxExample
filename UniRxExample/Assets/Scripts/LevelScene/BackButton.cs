using UniRx;

namespace UniRxExample.LevelScene
{
    public interface IBackButton
    {
        ReactiveProperty<bool> Clicked { get; }
    }

    public class BackButton : IBackButton, IClickable
    {
        public ReactiveProperty<bool> Clicked { get; private set; } = new(false);

        public void Click()
        {
            Clicked.Value = true;
        }
    }
}