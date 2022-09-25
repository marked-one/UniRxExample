using UnityEngine;
using Zenject;
using UniRx;

namespace UniRxExample.MainScene.Transition
{
    public class TransitionView : MonoBehaviour
    {
        [SerializeField] GameObject _transitionScreen;

        [Inject] SetActiveViewModel ViewModel { get; set; }

        void Awake()
        {
            _transitionScreen.SetActive(false);
            ViewModel.IsActive.SubscribeToGameObjectSetActive(_transitionScreen).AddTo(this);
        }
    }
}
