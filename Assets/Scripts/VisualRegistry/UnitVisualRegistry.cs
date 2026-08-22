using System.Collections.Generic;
using UI;

namespace Gameplay.VisualRegistry
{
    public class UnitVisualRegistry : IUnitVisualRegistry
    {
        private readonly Dictionary<IUnit, UnitView> _registry = new();

        public void AddToRegistry(IUnit unit, UnitView visual)
        {   
            _registry.Add(unit, visual);
        }

        public UnitView GetUnitView(IUnit unit)
        {
            return _registry[unit];
        }

        public void RemoveFromRegistry(IUnit unit)
        {
            _registry.Remove(unit);
        }
    }

}

