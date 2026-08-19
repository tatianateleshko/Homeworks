using UnityEngine;

public class UnitBase : IUnit
{
    public string Name => _name;

    public float Health => _health;

    public float AttackValue => _attackValue;

    public bool IsEnemy => _isEnemy;

    public IUnitData UnitData => _unitData;
    public ITeam Team => _team;

    private string _name;
    private float _health;
    private float _attackValue;
    private bool _isEnemy;
    private IUnitData _unitData;
    private ITeam _team;
    private IUnit _unitImplementation;

    public virtual void Attack(IUnit target)
    {

    }

    public void SetTeam(ITeam team)
    {
        _team = team;
    }

    public float GetCurrentHealth()
    {
        return _health;
    }

    public UnitBase(string name, float health, float attackValue, IUnitData unitData )
    {
        _name = name;
        _health = health;
        _attackValue = attackValue;
        _unitData = unitData;
    }
}
