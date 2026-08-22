using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Services.UnitFactory;
using UnityEngine;

namespace Services.TeamService
{
    public class TeamService : ITeamService 
    {
        private readonly IUnitFactory  _unitFactory;
        
        private TeamSpawnConfig _teamSpawn;
        
        private List<ITeam> _activeTeams = new List<ITeam>();
        private ITeam _playerTeam;
        public TeamService(IUnitFactory unitFactory, TeamSpawnConfig teamSpawn)
        {
            _unitFactory = unitFactory;
            _teamSpawn = teamSpawn;
        }
        
        public ITeam CreateTeam(string teamName)
        {
            var spawnData =  _teamSpawn.GetTeamSpawnData(teamName);
            
            if (spawnData == null)
            {
                Debug.LogError($"Team {teamName} does not exist");
            }

                   
            var units = new List<IUnit>();
            
            foreach (var unit in  spawnData.Units)
            {
                var newUnit =  _unitFactory.CreateUnit(unit);
                units.Add(newUnit);
            }
            
            var newTeam = new Team(spawnData.Name, spawnData.IsEnemy, units);

            
            if (!spawnData.IsEnemy)
            {
                _playerTeam = newTeam;
                foreach (var unit in _playerTeam.Units)
                {
                    unit.SetTeam(_playerTeam);
                }
            }
            else
            {
                foreach (var unit in newTeam.Units)
                {
                    unit.SetTeam(newTeam);
                }
            }
            

            _activeTeams.Add(newTeam);
            return newTeam;
        }


        public ITeam GetPlayerTeam()
        {
            return _playerTeam;
        }
        
        public ITeam GetActiveTeam(string teamName)
        {
            foreach (var team in _activeTeams)
            {
                if (team.TeamName == teamName)
                    return team;
            }
            return null;
        }

        public IEnumerable<ITeam> GetActiveTeams()
        {
            return _activeTeams;
        }
    }
}
