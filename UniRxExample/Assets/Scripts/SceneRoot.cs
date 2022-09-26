using UnityEngine;
using Zenject;

namespace UniRxExample
{
    public abstract class SceneRoot : MonoBehaviour
    {
        [Inject] IScene Scene { get; set; }

        void Start() => Scene.Start();
    }
}