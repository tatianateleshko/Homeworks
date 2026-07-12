using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
   public override void InstallBindings()
   {
        ChestInstaller.Install(Container);
        GameplaySingnalsInstaller.Install(Container);
   }

}
