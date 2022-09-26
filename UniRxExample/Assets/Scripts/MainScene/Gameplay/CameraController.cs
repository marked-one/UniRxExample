using UniRx;
using UnityEngine;
using Zenject;

namespace UniRxExample.MainScene.Gameplay
{
    public class CameraController : MonoBehaviour
    {
        [Inject] MovableViewModel ViewModel { get; set; }

        void Awake() => ViewModel.Position.SubscribeToTransformPosition(transform).AddTo(this);
    }
}