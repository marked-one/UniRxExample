using System.Linq;
using Zenject;
using UniRxExample.MainScene.IntroLoading;
using UniRxExample.MainScene.Transition;
using UnityEngine;

namespace UniRxExample.MenuScene
{
    public class MenuSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallScene();
            InstallMenu();
        }

        void InstallScene()
        {
            var nextSceneName = "Level";
            Container.Bind<string>().FromInstance(nextSceneName).WhenInjectedInto<MenuScene>();
            Container.Bind<IScene>().To<MenuScene>().AsSingle().WhenInjectedInto<MenuSceneRoot>();
        }

        void InstallMenu()
        {
        }
    }
}


