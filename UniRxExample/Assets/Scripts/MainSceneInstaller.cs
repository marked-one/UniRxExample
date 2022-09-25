using System.Linq;
using Zenject;
using UniRxExample.IntroLoading;
using UniRxExample.TransitionScreen;

namespace UniRxExample
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallIntroLoading();
            InstallLoadingScreen();
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
            Container.Bind<TransitionScreenModel>().AsSingle();
            Container.Bind<ITransitionScreenModel>().To<TransitionScreenModel>().FromResolve();
            Container.Bind<IActive>().To<TransitionScreenModel>().FromResolve().When(context => context.AllObjectTypes.Contains(typeof(TransitionScreenView)));
            Container.Bind<SetActiveViewModel>().AsSingle().WhenInjectedInto<TransitionScreenView>();
        }
    }
}


