using UniRx;

namespace UniRxExample.TransitionScreen
{
    public interface ITransitionScreenModel
    {
        void Activate();
        void Deactivate();
    }

    public class TransitionScreenModel : ITransitionScreenModel, IActive
    {
        public ReactiveProperty<bool> Active { get; private set; } = new(false);

        public void Activate() => Active.Value = true;
        public void Deactivate() => Active.Value = false;
    }
}