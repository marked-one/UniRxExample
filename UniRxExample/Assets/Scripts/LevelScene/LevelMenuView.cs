using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Zenject;

namespace UniRxExample.LevelScene
{
    public class LevelMenuView : MonoBehaviour
    {
        [SerializeField] Button _backButton;

        [Inject] ButtonViewModel ViewModel { get; set; }

        void Awake()
        {
            _backButton.gameObject.SetActive(true);
            ViewModel.Click.BindTo(_backButton);
        }
    }
}