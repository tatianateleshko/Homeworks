using System.Collections.Generic;

namespace  Services.TeamService
{
    public interface ITeamService
    {
        ITeam CreateTeam(string teamName);
        ITeam GetActiveTeam(string teamName);
        IEnumerable<ITeam> GetActiveTeams();
        ITeam GetPlayerTeam();

    }
}

