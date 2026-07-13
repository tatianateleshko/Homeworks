using UnityEngine;

public interface IUnit
{
    string Name { get; }
    float Health { get; }
    float AttackValue { get; }
    bool IsEnemy { get; }
    IUnitData UnitData { get; }

}
