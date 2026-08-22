using Cysharp.Threading.Tasks;
using Gameplay.VisualRegistry;


namespace Services.BattleService
{
    public class BattleService: IBattleService
    {
        private readonly IUnitVisualRegistry _unitVisualRegistry;

        public BattleService(IUnitVisualRegistry unitVisualRegistry)
        { 
            _unitVisualRegistry = unitVisualRegistry;
        }

        public async UniTask UnitsFight(IUnit attacker, IUnit defender)
        {
            var playerView = _unitVisualRegistry.GetUnitView(attacker);
            var enemyView = _unitVisualRegistry.GetUnitView(defender);

            attacker.Attack(defender);

            await playerView.AnimateAttack(enemyView);

            enemyView.DestroyView();

            _unitVisualRegistry.RemoveFromRegistry(defender);

            playerView.SetSelected(false);
        }
    }
}
