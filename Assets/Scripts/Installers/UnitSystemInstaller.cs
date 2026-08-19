using UI;
using Zenject;

namespace Installers
{
    public class UnitSystemInstaller : Installer<UnitSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TeamSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<UnitsViewSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleSystem>().AsSingle();
        }
    }
}