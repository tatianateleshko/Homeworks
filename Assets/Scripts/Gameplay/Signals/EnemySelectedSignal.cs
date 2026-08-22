

namespace Code.Gameplay.Signals
{
      public struct EnemySelectedSignal
      {
            public readonly IUnit DefenderUnit;

            public EnemySelectedSignal(IUnit defenderUnit)
            {
                DefenderUnit = defenderUnit;
            }

      }
}