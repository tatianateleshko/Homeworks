using GameStates;
using Services.GameStateMachine;
using Services.SceneLoader;
using Services.StateFactory;
using Zenject;

namespace Installers
{
    public class BootstrapInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IConfigDataService>().To<ConfigDataService>().AsSingle();
            Container.Bind<ITimeService>().To<TimeService>().AsSingle();
            BindGameStateMachine();
            BindEventBus();
        }

        private void BindGameStateMachine()
        {
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelLoopState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadLevelState>().AsSingle();
        }


        private void BindEventBus()
        {
            SignalBusInstaller.Install(Container);
            Container.Bind<IEventBus>().To<EventBus>().AsSingle();

        }

    }

}
