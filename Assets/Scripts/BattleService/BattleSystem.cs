using Code.Gameplay.Signals;
using Code.Infrastructure.Services.EventBus;
using Cysharp.Threading.Tasks;
using Services.BattleService;
using Services.UnitSelectionService;
using Zenject;


namespace Gameplay.Systems
{
    public class BattleSystem : IInitializable
    {
        private readonly IEventBus _eventBus;
        private readonly IBattleService _battleService;
        private readonly IUnitSelectionService _unitSelectionService;

        public BattleSystem(IEventBus eventBus, IBattleService battleService, IUnitSelectionService unitSelectionService)  
        {
            _eventBus =  eventBus;
            _battleService = battleService;
            _unitSelectionService = unitSelectionService;
        }
    
        public void Initialize()
        {
            _eventBus.Subscribe<EnemySelectedSignal>(OnEnemySelected);
        }

        private void OnEnemySelected(EnemySelectedSignal signal)
        {
            HandleFightAsync(signal).Forget();
        }

        private async UniTask HandleFightAsync(EnemySelectedSignal signal)
        {
            var attacker = _unitSelectionService.GetSelectedUnit();
  
            await _battleService.UnitsFight(attacker, signal.DefenderUnit);

        }
    }

}
