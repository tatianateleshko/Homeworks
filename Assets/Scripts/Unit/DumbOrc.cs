using UnityEngine;

namespace Gameplay.Units
{
    public class DumbOrc : UnitBase
    {
        private string _name;
        private float _health;
        private float _attackValue;
        private bool _isEnemy;
        private IUnitData _unitData;

        public DumbOrc(string name, float health, float attackValue,  IUnitData unitData) : base(name,
            health, attackValue, unitData)
        {
            _name = name;
            _health = health;
            _attackValue = attackValue;
            _unitData = unitData;
        }

        public override void Attack(IUnit target)
        {
            var targetHealth = target.GetCurrentHealth();
            targetHealth -= _attackValue; 
        }
    }
}
