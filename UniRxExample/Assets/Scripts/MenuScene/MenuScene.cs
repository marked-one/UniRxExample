using System;
using UniRxExample.MainScene.TransitionScreen;
using Zenject;

namespace UniRxExample.MenuScene
{
    public class MenuScene : IScene
    {
        ITransition _transition;
        ISceneUnloader _sceneUnloader;
        ISceneLoader _sceneLoader;

        [Inject] 
        public MenuScene(ITransition transition, ISceneUnloader unloader, ISceneLoader loader,
                         ISceneUnloader sceneUnloader, ISceneLoader sceneLoader)
        {
            if (transition == null)
                throw new ArgumentNullException(nameof(transition));

            if (sceneUnloader == null)
                throw new ArgumentNullException(nameof(sceneUnloader));

            if (sceneLoader == null)
                throw new ArgumentNullException(nameof(sceneLoader));

            _transition = transition;
            _sceneUnloader = sceneUnloader;
            _sceneLoader = sceneLoader;
        }

        public void OnStart()
        {
            // TODO: subscribe to UI button

            //_transition.Start(_sceneUnloader, _sceneLoader);
        }
    }
}