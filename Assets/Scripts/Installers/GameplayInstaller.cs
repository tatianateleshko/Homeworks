using Code.Infrastructure.Services.EventBus;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private TeamSpawnConfig _teamSpawnConfig;
       
        public override void InstallBindings()
        {
            Container.BindInstance(_teamSpawnConfig);
            UnitInstaller.Install(Container);
            SignalBusInstaller.Install(Container);
            Container.Bind<IEventBus>().To<ZenjectEventBus>().AsSingle();
            GameplaySignalsInstaller.Install(Container);
        }
    }
}
