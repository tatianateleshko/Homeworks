using UnityEngine;

public class UnitBase : IUnit
{
    public string Name => _name;

    public float Health => _health;

    public float AttackValue => _attackValue;

    public IUnitData UnitData => _unitData;
    public ITeam Team => _team;

    private string _name;
    private float _health;
    private float _attackValue;
    private IUnitData _unitData;
    private ITeam _team;

    public virtual void Attack(IUnit target)
    {
        target.TakeDamage(_attackValue);
    }

    public void SetTeam(ITeam team)
    {
        _team = team;
    }

    public float GetCurrentHealth()
    {
        return _health;
    }

    public void SetCurrentHealth(float health)
    {
        _health = health;
    }

    public void TakeDamage(float attackValue)
    {
        _health -= attackValue;
    }

    public UnitBase(string name, float health, float attackValue, IUnitData unitData )
    {
        _name = name;
        _health = health;
        _attackValue = attackValue;
        _unitData = unitData;
    }
}
