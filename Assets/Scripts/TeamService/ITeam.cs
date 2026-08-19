 using System.Collections.Generic;

 public interface ITeam
    {
         string TeamName { get; }
         bool IsEnemy  { get; }
         IEnumerable<IUnit> Units { get; }
         
    }
