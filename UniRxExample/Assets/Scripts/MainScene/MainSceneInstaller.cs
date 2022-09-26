using System.Linq;
using Zenject;
using UniRxExample.MainScene.IntroLoading;
using UniRxExample.MainScene.TransitionScreen;
using UnityEngine;
using UniRxExample.TransitionScreen;
using UniRxExample.MainScene.Gameplay;
using UniRxExample.LevelScene.Gameplay;

namespace UniRxExample.MainScene
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] MainSceneUnloader _introUnloader;
        [SerializeField] CameraController _cameraController;

        public override void InstallBindings()
        {
            InstallScene();
            InstallIntroLoading();
            InstallTransition();
            InstallGameplay();
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
            Container.Bind<IntroLoader>().AsSingle();
            Container.Bind<IIntroLoader>().To<IntroLoader>().FromResolve();
            Container.Bind<IProgress>().To<IntroLoader>().FromResolve().When(context => context.AllObjectTypes.Contains(typeof(IntroLoaderView)));
            Container.Bind<ProgressViewModel>().WhenInjectedInto<IntroLoaderView>();
        }

        void InstallTransition()
        {
            Container.Bind<Transition>().AsSingle();
            Container.Bind<ITransition>().To<Transition>().FromResolve();
            Container.Bind<IActive>().To<Transition>().FromResolve().When(context => context.AllObjectTypes.Contains(typeof(TransitionView)));
            Container.Bind<SetActiveViewModel>().AsSingle().WhenInjectedInto<TransitionView>();
        }

        void InstallGameplay()
        {
            Container.Bind<PlayerPosition>().AsSingle();
            Container.Bind<IMover>().To<PlayerPosition>().FromResolve();
            Container.Bind<IMovable>().To<PlayerPosition>().FromResolve();
            Container.Bind<MovableViewModel>().AsSingle().WhenInjectedInto<CameraController>();
        }
    }
}


