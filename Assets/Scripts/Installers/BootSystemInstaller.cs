using Services.Bootstrapper;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class BootSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Bootstrapper>().AsSingle().NonLazy();
        }
    }

}
