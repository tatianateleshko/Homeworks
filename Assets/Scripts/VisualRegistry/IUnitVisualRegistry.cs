using UI;

namespace Gameplay.VisualRegistry
{
    public interface IUnitVisualRegistry
    {
        void AddToRegistry(IUnit unit, UnitView visual);

        void RemoveFromRegistry(IUnit unit);
        UnitView GetUnitView(IUnit unit);
    }
}
