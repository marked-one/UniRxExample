using System.Collections.Generic;
using UnityEngine;

namespace UniRxExample.MainScene
{
    public class MainSceneUnloader : MonoBehaviour, ISceneUnloader
    {
        [SerializeField] List<GameObject> _gameObjectsToUnloadFromMainScene;

        public void Unload()
        {
            foreach(var gameObject in _gameObjectsToUnloadFromMainScene)
                Destroy(gameObject);

            _gameObjectsToUnloadFromMainScene.Clear();
        }
    }
}
