using Code.Gameplay.Signals;
using Code.Infrastructure.Services.EventBus;
using UnityEngine;
using Zenject;

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
        _eventBus.Subscribe<EnemySelectedSignal>(signal => _battleService.UnitsFight(_unitSelectionService.GetSelectedUnit(),  signal.DefenderUnit));
    }
}
