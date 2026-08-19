using Services.TeamService;
using UnityEngine;
using Zenject;

public class TeamSystem:  IInitializable
{
    private readonly ITeamService  _teamService;

    public TeamSystem(ITeamService teamService)
    {
        _teamService = teamService;
    }
    
    public void Initialize()
    {
        _teamService.CreateTeam("Enemy");
        _teamService.CreateTeam("Player");
    }
}
