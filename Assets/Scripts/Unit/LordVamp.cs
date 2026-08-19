using UnityEngine;

namespace  Gameplay.Units 
{
    public class LordVamp : UnitBase
    {
        private string _name;
        private float _health;
        private float _attackValue;
        private bool _isEnemy;
        private IUnitData _unitData;
        
        public LordVamp(string name, float health, float attackValue,  IUnitData unitData) : base(name, health, attackValue,unitData)
        {
            _name = name;
            _attackValue = attackValue;
            _health = health;
            _unitData = unitData;
            
        }

        public override void Attack(IUnit target)
        {
            base.Attack(target);
        }
    }
}

