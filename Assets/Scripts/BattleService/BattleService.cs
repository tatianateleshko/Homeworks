using UnityEngine;

public class BattleService: IBattleService
{
    public void UnitsFight(IUnit attacker, IUnit defender)
    {
        attacker.Attack(defender);
    }
}
