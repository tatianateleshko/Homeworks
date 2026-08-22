using Gameplay.VisualRegistry;

namespace Services.UnitSelectionService
{
    public class UnitSelectionService: IUnitSelectionService
    {
        private readonly IUnitVisualRegistry _visualRegistry;
        public UnitSelectionService(IUnitVisualRegistry unitVisualRegistry)
        {
            _visualRegistry = unitVisualRegistry;
        }
    
        private IUnit _selectedUnit;    
    
        public void SetUnitSelected(IUnit unit)
        {
            _selectedUnit = unit;
            var unitVisual = _visualRegistry.GetUnitView(unit);
            unitVisual.SetSelected(true);
        }

        public IUnit GetSelectedUnit()
        {
            return _selectedUnit;
        }
    }
}
