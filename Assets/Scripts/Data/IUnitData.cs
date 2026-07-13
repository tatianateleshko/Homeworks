using Gameplay.Enums;
using UnityEngine;

public interface IUnitData
{
    string UnitName { get; }
    Sprite Icon { get; }
    float Health { get; }
    float AttackValue { get; }
    
    UnitType UnitType { get; }
}  