using UniRx;

namespace UniRxExample.MenuScene
{
    public interface IPlayButton
    {
        ReactiveProperty<bool> Clicked { get; }
    }

    public class PlayButton : IPlayButton, IClickable
    {
        public ReactiveProperty<bool> Clicked { get; private set; } = new(false);

        public void Click()
        {
            Clicked.Value = true;
        }
    }
}