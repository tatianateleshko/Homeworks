
    using System.Collections.Generic;

    public class Team : ITeam
    {
        public string TeamName => _teamName;
        public bool IsEnemy => _isEnemy;
        public IEnumerable<IUnit> Units => _units;

        public Team(string teamName, bool isEnemy, List<IUnit> units)
        {
            _teamName = teamName;
            _isEnemy = isEnemy;
            _units = units;
        }
        
        private string _teamName;
        private bool _isEnemy;
        private List<IUnit> _units;
    }
