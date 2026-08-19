using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UnitsWindow : MonoBehaviour
    {
        [SerializeField] private List<UnitView> _enemyViews;
        [SerializeField] private List<UnitView> _playersViews;

        [Inject]
        public void Construct(IUnitsViewPresenter unitsViewPresenter)
        {
            unitsViewPresenter.Register(this);
        }
    
        public void SetUpUnits(IEnumerable<ITeam> teams)
        {
            foreach (var team in teams)
            {
                if(team.IsEnemy)
                    FillUnitsInfo(team.Units, _enemyViews);
                else
                    FillUnitsInfo(team.Units, _playersViews);
            }
        }
        
        private void FillUnitsInfo(IEnumerable<IUnit> units, List<UnitView> unitViews)
        {
            foreach (var unit in units)
            {
                var unitData = unit.UnitData;
                foreach (var view in unitViews)
                {
                    view.SetIcon(unitData.Icon);
                    view.SetStats($"{unit.Health} / {unit.AttackValue}");
                    view.SetUnit(unit);
                } 
            }
        }
    }  
}

