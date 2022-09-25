using System;
using UnityEngine.SceneManagement;

namespace UniRxExample
{
    public interface ISceneUnloader
    {
        IObservable<float> Unload();
    }

    public class SceneUnloader : ISceneUnloader
    {
        string _sceneName;

        public SceneUnloader(string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName))
                throw new ArgumentException("Invalid scene name", nameof(sceneName));

            _sceneName = sceneName;
        }

        public IObservable<float> Unload() => SceneManager.UnloadSceneAsync(_sceneName).ToObservable();
    }
}
