using System.Collections.Generic;
using System.Threading.Tasks;
using UniRxExample.IntroLoading;
using UniRxExample.TransitionScreen;
using UnityEngine;
using Zenject;

namespace UniRxExample
{
    public class AppRoot : MonoBehaviour
    {
        [SerializeField] List<GameObject> _gameObjectsToUnloadFromMainScene;

        [Inject] IIntroLoadingModel IntroLoader {get; set; }
        [Inject] ITransitionScreenModel TransitionScreen {get; set; }

        async Task Start()
        {
            await IntroLoader.Load();

            TransitionScreen.Activate();
            foreach(var gameObject in _gameObjectsToUnloadFromMainScene)
                Destroy(gameObject);

            _gameObjectsToUnloadFromMainScene.Clear();
        }
    }
}