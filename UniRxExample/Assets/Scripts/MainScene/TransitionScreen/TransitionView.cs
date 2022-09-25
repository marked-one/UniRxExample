using UnityEngine;
using Zenject;
using UniRx;
using UniRxExample.TransitionScreen;

namespace UniRxExample.MainScene.TransitionScreen
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
