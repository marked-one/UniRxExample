using System.Linq;
using Zenject;
using UniRxExample.MainScene.IntroLoading;
using UniRxExample.MainScene.TransitionScreen;
using UnityEngine;
using UniRxExample.TransitionScreen;

namespace UniRxExample.MainScene
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] MainSceneUnloader _introUnloader;

        public override void InstallBindings()
        {
            InstallScene();
            InstallIntroLoading();
            InstallTransition();
        }

        void InstallScene()
        {
            Container.BindInstance("Menu").When(context => context.AllObjectTypes.Contains(typeof(MainScene)));
            Container.Bind<ISceneUnloader>().FromInstance(_introUnloader).WhenInjectedInto<MainScene>();
            Container.Bind<ISceneLoader>().To<SceneLoader>().WhenInjectedInto<MainScene>();
            Container.Bind<IScene>().To<MainScene>().WhenInjectedInto<MainSceneRoot>();
        }

        void InstallIntroLoading()
        {
            Container.Bind<IntroLoadingModel>().AsSingle();
            Container.Bind<IIntroLoadingModel>().To<IntroLoadingModel>().FromResolve();
            Container.Bind<IProgress>().To<IntroLoadingModel>().FromResolve().When(context => context.AllObjectTypes.Contains(typeof(IntroLoadingView)));
            Container.Bind<ProgressViewModel>().WhenInjectedInto<IntroLoadingView>();
        }

        void InstallTransition()
        {
            Container.Bind<Transition>().AsSingle();
            Container.Bind<ITransition>().To<Transition>().FromResolve();
            Container.Bind<IActive>().To<Transition>().FromResolve().When(context => context.AllObjectTypes.Contains(typeof(TransitionView)));
            Container.Bind<SetActiveViewModel>().AsSingle().WhenInjectedInto<TransitionView>();
        }
    }
}


