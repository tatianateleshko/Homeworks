using Cysharp.Threading.Tasks;


namespace Services.BattleService
{
    public interface IBattleService
    {
        UniTask UnitsFight(IUnit attacker, IUnit defender);
    }

}
