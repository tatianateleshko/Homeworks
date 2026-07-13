using UnityEngine;

namespace Services.UnitFactory
{
    public interface IUnitFactory  {
        IUnit CreateUnit(IUnitData unitData);
    }

}
