using UnityEngine;
using Zenject;
using UniRx;

namespace UniRxExample.TransitionScreen
{
    public class TransitionScreenView : MonoBehaviour
    {
        [SerializeField] GameObject _transitionScreen;

        [Inject] SetActiveViewModel ViewModel { get; set; }

        void Awake()
        {
            _transitionScreen.SetActive(false);
            ViewModel.Active.SubscribeToGameObjectSetActive(_transitionScreen).AddTo(this);
        }
    }
}
