using UnityEngine;
using Zenject;

namespace  Installers
{
    public class BattleSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            UnitSystemInstaller.Install(Container);
            //GameplaySignalsInstaller.Install(Container);
        }
    }
}

