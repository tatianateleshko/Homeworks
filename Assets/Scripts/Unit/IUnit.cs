using UnityEngine;

public interface IUnit
{
    string Name { get; }
    float Health { get; }
    float AttackValue { get; }
    
    bool IsEnemy { get; }
    IUnitData UnitData { get; }
    ITeam Team { get; }
    
    void Attack(IUnit target);
    void SetTeam(ITeam team);   
    
    float GetCurrentHealth();
 
}
