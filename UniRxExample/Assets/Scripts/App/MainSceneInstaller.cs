using Zenject;
using UniRxExample.IntroLoading;
using System.Linq;

namespace UniRxExample
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallIntroLoader();
        }

        void InstallIntroLoader()
        {
            Container.Bind<IntroLoader>().AsSingle();
            Container.Bind<IIntroLoader>().To<IntroLoader>().FromResolve();
            Container.Bind<IProgress>().To<IntroLoader>().FromResolve().When(context => context.AllObjectTypes.Contains(typeof(IntroLoadingScreenView)));
            Container.Bind<ProgressViewModel>().AsSingle().WhenInjectedInto<IntroLoadingScreenView>();
        }
    }
}


