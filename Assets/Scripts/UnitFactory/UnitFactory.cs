using Gameplay.Enums;
using Gameplay.Units;

namespace Services.UnitFactory
{
    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(IUnitData unitData)
        {
            var unitType = unitData.UnitType;

            switch (unitType)
            {
                case UnitType.DumbOrc:
                    return CreateDumbOrc(unitData.UnitName,  unitData.Health, unitData.AttackValue, unitData);
                case UnitType.LordVamp:
                    return CreateLordVamp(unitData.UnitName, unitData.Health, unitData.AttackValue, unitData);
            }
            return null;
        }


        private IUnit CreateDumbOrc(string name, float health, float attackValue,  IUnitData unitData)
        {
            var orc = new DumbOrc(name, health, attackValue, unitData);
            return orc; 
        }
        
        private IUnit CreateLordVamp(string name, float health, float attackValue,  IUnitData unitData)
        {
            var orc = new LordVamp(name, health, attackValue, unitData);
            return orc; 
        }
    }

}
