using Code.Gameplay.Signals;
using UnityEngine;
using Zenject;

public class GameplaySignalsInstaller : Installer<GameplaySignalsInstaller>
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<UnitSelectSignal>();
        Container.DeclareSignal<EnemySelectedSignal>();
    }
}
