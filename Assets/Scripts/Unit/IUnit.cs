using UnityEngine;

public interface IUnit
{
    string Name { get; set; }
    float Health { get; set; }
    float AttackValue { get; set; }
    bool IsEnemy { get; set; }
}
