using UnityEngine;

public class UnitBase : IUnit
{
    public string Name => _name;

    public float Health => _health;

    public float AttackValue => _attackValue;

    public bool IsEnemy => _isEnemy;

    public IUnitData UnitData => _unitData;

    public UnitBase(string name, float health, float attackValue,  bool isEnemy, IUnitData unitData )
    {
        _name = name;
        _health = health;
        _attackValue = attackValue;
        _isEnemy = isEnemy;
        _unitData = unitData;
    }
    private string _name;
    private float _health;
    private float _attackValue;
    private bool _isEnemy;
    private IUnitData _unitData;

}
