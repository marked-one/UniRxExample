using System;
using UnityEngine.SceneManagement;

namespace UniRxExample
{
    public interface ISceneLoader
    {
        IObservable<float> Load();
    }

    public class SceneLoader : ISceneLoader
    {
        string _sceneName;

        public SceneLoader(string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName))
                throw new ArgumentException("Invalid scene name", nameof(sceneName));

            _sceneName = sceneName;
        }

        public IObservable<float> Load() => SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive).ToObservable();
    }
}
