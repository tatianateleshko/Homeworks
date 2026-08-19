
using Gameplay.Enums;
using UI;

namespace Code.Gameplay.Signals
{
  public struct EnemySelectedSignal
  {
    public IUnit DefenderUnit;
    //public UnitView  UnitView;
    public EnemySelectedSignal(IUnit defenderUnit)
    {
      DefenderUnit = defenderUnit;
    }

   
  }
}