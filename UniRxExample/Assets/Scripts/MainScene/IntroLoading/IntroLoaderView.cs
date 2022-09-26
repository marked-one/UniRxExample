using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UniRxExample.MainScene.IntroLoading
{
    public class IntroLoaderView : MonoBehaviour
    {
        [SerializeField] GameObject _progressBar;
        [SerializeField] Image _progressMask;

        [Inject] ProgressViewModel ViewModel { get; set; }

        void Awake()
        {
            _progressBar.SetActive(true);
            ViewModel.Progress.SubscribeToImageFillAmount(_progressMask).AddTo(this);
        }
    }
}
