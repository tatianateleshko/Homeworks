using Services.TeamService;
using Services.UnitFactory;
using Zenject;
using UI;
using Services.BattleService;
using Gameplay.VisualRegistry;
using Services.UnitSelectionService;

namespace Installers
{
    public class UnitInstaller : Installer<UnitInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IUnitFactory>().To<UnitFactory>().AsSingle();
            Container.Bind<ITeamService>().To<TeamService>().AsSingle();
            Container.Bind<IUnitsViewPresenter>().To<UnitsViewPresenter>().AsSingle();
            Container.Bind<IUnitSelectionService>().To<UnitSelectionService>().AsSingle();
            Container.Bind<IBattleService>().To<BattleService>().AsSingle();
            Container.Bind<IUnitVisualRegistry>().To<UnitVisualRegistry>().AsSingle();
        }
    }

}
