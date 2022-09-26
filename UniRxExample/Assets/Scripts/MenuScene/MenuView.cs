using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Zenject;

namespace UniRxExample.MenuScene
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] Button _playButton;

        [Inject] ButtonViewModel ViewModel { get; set; }

        void Awake()
        {
            _playButton.gameObject.SetActive(true);
            ViewModel.Click.BindTo(_playButton);
        }
    }
}