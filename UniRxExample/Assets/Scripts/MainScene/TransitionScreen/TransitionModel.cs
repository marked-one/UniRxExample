namespace UniRxExample.MainScene.Transition
{
    public interface ITransitionModel
    {
        void Activate();
        void Deactivate();
    }

    public class TransitionModel : ITransitionModel, IActive
    {
        public bool IsActive { get; private set; } = false;

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
    }
}