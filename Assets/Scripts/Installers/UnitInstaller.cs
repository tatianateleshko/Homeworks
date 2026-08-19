using Services.TeamService;
using Services.UnitFactory;
using UnityEngine;
using Zenject;
using UI;

public class UnitInstaller : Installer<UnitInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IUnitFactory>().To<UnitFactory>().AsSingle();
        Container.Bind<ITeamService>().To<TeamService>().AsSingle();
        Container.Bind<IUnitsViewPresenter>().To<UnitsViewPresenter>().AsSingle();
        Container.Bind<IUnitSelectionService>().To<UnitSelectionService>().AsSingle();
        Container.Bind<IBattleService>().To<BattleService>().AsSingle();
    }
}
