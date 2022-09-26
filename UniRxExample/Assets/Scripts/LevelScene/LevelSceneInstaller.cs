using System.Linq;
using UniRxExample.LevelScene.Gameplay;
using Zenject;

namespace UniRxExample.LevelScene
{
    public class LevelSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallScene();
            InstallLevelMenuView();
            InstallGameplay();
        }

        void InstallScene()
        {
            Container.BindInstance("Level").When(context => context.ObjectType == typeof(SceneUnloader) && context.AllObjectTypes.Contains(typeof(LevelScene)));
            Container.BindInstance("Menu").When(context => context.ObjectType == typeof(SceneLoader) && context.AllObjectTypes.Contains(typeof(LevelScene)));
            Container.Bind<ISceneUnloader>().To<SceneUnloader>().WhenInjectedInto<LevelScene>();
            Container.Bind<ISceneLoader>().To<SceneLoader>().WhenInjectedInto<LevelScene>();
            Container.Bind<IScene>().To<LevelScene>().WhenInjectedInto<LevelSceneRoot>();
        }

        void InstallLevelMenuView()
        {
            Container.Bind<BackButton>().AsSingle().When(context => context.AllObjectTypes.Contains(typeof(LevelMenuView)) || context.AllObjectTypes.Contains(typeof(LevelScene)));
            Container.Bind<IBackButton>().To<BackButton>().FromResolve().WhenInjectedInto<LevelScene>();
            Container.Bind<IClickable>().To<BackButton>().FromResolve().When(context => context.AllObjectTypes.Contains(typeof(LevelMenuView)));
            Container.Bind<ButtonViewModel>().WhenInjectedInto<LevelMenuView>();
        }

        void InstallGameplay()
        {
            Container.Bind<PositionViewModel>().WhenInjectedInto<PlayerController>();
        }
    }
}


