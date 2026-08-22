
public interface IUnit
{
    string Name { get; }
    float Health { get; }
    float AttackValue { get; }
    
    IUnitData UnitData { get; }
    ITeam Team { get; }
    
    void Attack(IUnit target);
    void SetTeam(ITeam team);   
 
    float GetCurrentHealth();

    void SetCurrentHealth(float health);

    void TakeDamage(float attackValue);
 
}
