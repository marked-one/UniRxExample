using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace UniRxExample.MainScene
{
    public class MainSceneUnloader : MonoBehaviour, ISceneUnloader
    {
        [SerializeField] List<GameObject> _gameObjectsToUnloadFromMainScene;

        public IObservable<float> Unload()
        {
            foreach(var gameObject in _gameObjectsToUnloadFromMainScene)
                Destroy(gameObject);

            _gameObjectsToUnloadFromMainScene.Clear();
            return Observable.Return(1f);
        }
    }
}
