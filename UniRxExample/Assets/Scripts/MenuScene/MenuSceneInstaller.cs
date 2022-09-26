using System.Linq;
using Zenject;

namespace UniRxExample.MenuScene
{
    public class MenuSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallScene();
            InstallMenuView();
        }

        void InstallScene()
        {
            Container.BindInstance("Menu").When(context => context.ObjectType == typeof(SceneUnloader) && context.AllObjectTypes.Contains(typeof(MenuScene)));
            Container.BindInstance("Level").When(context => context.ObjectType == typeof(SceneLoader) && context.AllObjectTypes.Contains(typeof(MenuScene)));
            Container.Bind<ISceneUnloader>().To<SceneUnloader>().WhenInjectedInto<MenuScene>();
            Container.Bind<ISceneLoader>().To<SceneLoader>().WhenInjectedInto<MenuScene>();
            Container.Bind<IScene>().To<MenuScene>().WhenInjectedInto<MenuSceneRoot>();
        }

        void InstallMenuView()
        {
            Container.Bind<PlayButton>().AsSingle().When(context => context.AllObjectTypes.Contains(typeof(MenuView)) || context.AllObjectTypes.Contains(typeof(MenuScene)));
            Container.Bind<IPlayButton>().To<PlayButton>().FromResolve().WhenInjectedInto<MenuScene>();
            Container.Bind<IClickable>().To<PlayButton>().FromResolve().When(context => context.AllObjectTypes.Contains(typeof(MenuView)));
            Container.Bind<ButtonViewModel>().WhenInjectedInto<MenuView>();
        }
    }
}


