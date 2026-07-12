using UnityEngine;
using Zenject;

public class GameplaySingnalsInstaller : Installer<GameplaySingnalsInstaller>
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<ChestOpenRewardSignal>();
    }
}
