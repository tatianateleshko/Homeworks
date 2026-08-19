using Services.TeamService;

namespace UI
{
    public class UnitsViewPresenter : IUnitsViewPresenter
    {
        private readonly ITeamService _teamService;
        private UnitsWindow _unitsWindow;

        public UnitsViewPresenter(ITeamService teamService)
        {
            _teamService = teamService;
        }
        
        public void ShowUnits()
        {
            _unitsWindow.SetUpUnits(_teamService.GetActiveTeams());
        }
        
        public void Register(UnitsWindow unitsWindow)
        {
            _unitsWindow = unitsWindow;
        }
    }
}
