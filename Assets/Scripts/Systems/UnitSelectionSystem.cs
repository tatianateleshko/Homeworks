using Code.Gameplay.Signals;
using Code.Infrastructure.Services.EventBus;
using Services.UnitSelectionService;
using Zenject;

namespace Gameplay.Systems
{
    public class UnitSelectionSystem: IInitializable
    {
        private readonly IEventBus _eventBus;
        private readonly IUnitSelectionService _unitSelectionService;
    
        public UnitSelectionSystem(IEventBus eventBus,  IUnitSelectionService unitSelectionService)
        {
            _eventBus = eventBus;
            _unitSelectionService = unitSelectionService;
        }
    
        public void Initialize()
        {
            _eventBus.Subscribe<UnitSelectSignal>(signal => _unitSelectionService.SetUnitSelected(signal.SelectedUnit));
        }
    }

}
