using System.Linq;
using Zenject;
using UniRxExample.MainScene.IntroLoading;
using UniRxExample.MainScene.Transition;
using UnityEngine;

namespace UniRxExample.MainScene
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] MainSceneUnloader _introUnloader;

        public override void InstallBindings()
        {
            InstallScene();
            InstallIntroLoading();
            InstallLoadingScreen();
        }

        void InstallScene()
        {
            var nextSceneName = "Menu";
            Container.Bind<string>().FromInstance(nextSceneName).WhenInjectedInto<MainScene>();
            Container.Bind<ISceneUnloader>().FromInstance(_introUnloader);
            Container.Bind<IScene>().To<MainScene>().WhenInjectedInto<MainSceneRoot>();
        }

        void InstallIntroLoading()
        {
            Container.Bind<IntroLoadingModel>().AsSingle();
            Container.Bind<IIntroLoadingModel>().To<IntroLoadingModel>().FromResolve();
            Container.Bind<IProgress>().To<IntroLoadingModel>().FromResolve().When(context => context.AllObjectTypes.Contains(typeof(IntroLoadingView)));
            Container.Bind<ProgressViewModel>().AsSingle().WhenInjectedInto<IntroLoadingView>();
        }

        void InstallLoadingScreen()
        {
            Container.Bind<TransitionModel>().AsSingle();
            Container.Bind<ITransitionModel>().To<TransitionModel>().FromResolve();
            Container.Bind<IActive>().To<TransitionModel>().FromResolve().When(context => context.AllObjectTypes.Contains(typeof(TransitionView)));
            Container.Bind<SetActiveViewModel>().AsSingle().WhenInjectedInto<TransitionView>();
        }
    }
}


