namespace UniRxExample.MenuScene
{
    public interface IPlayButton
    {
        bool Clicked { get; }
    }

    public class PlayButton : IPlayButton, IClickable
    {
        public bool Clicked { get; private set; } = false;

        public void Click()
        {
            Clicked = true;
        }
    }
}