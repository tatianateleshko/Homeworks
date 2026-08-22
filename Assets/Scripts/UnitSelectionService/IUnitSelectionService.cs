

namespace Services.UnitSelectionService
{
    public interface IUnitSelectionService
    {
        void SetUnitSelected(IUnit unit);
        IUnit GetSelectedUnit();
    }

}
