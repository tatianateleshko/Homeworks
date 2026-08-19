using Services.TeamService;
using UnityEngine;

public class UnitSelectionService: IUnitSelectionService
{
    private readonly ITeamService _teamService;
    
    public UnitSelectionService(ITeamService teamService)
    {
        _teamService = teamService;
    }
    
    private IUnit _selectedUnit;    
    
    public void SetUnitSelected(IUnit unit)
    {
        if(_teamService.GetPlayerTeam() != unit.Team)
            _selectedUnit = unit;
    }

    public IUnit GetSelectedUnit()
    {
        return _selectedUnit;
    }
}
