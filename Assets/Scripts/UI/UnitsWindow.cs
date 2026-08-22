using Cysharp.Threading.Tasks;
using Gameplay.VisualRegistry;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UnitsWindow : MonoBehaviour
    {
        [SerializeField] private List<UnitView> _enemyViews;
        [SerializeField] private List<UnitView> _playersViews;

        private IUnitVisualRegistry _visualRegistry;

        [Inject]
        public void Construct(IUnitsViewPresenter unitsViewPresenter, IUnitVisualRegistry unitVisualRegistry)
        {
            unitsViewPresenter.Register(this);
            _visualRegistry = unitVisualRegistry;
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
            if (_visualRegistry == null)
            {
                Debug.LogError("registry is null");
                return;
            }

            var unitList = units as IList<IUnit> ?? new List<IUnit>(units);

            if (unitList.Count > unitViews.Count)
            {
                Debug.LogWarning($"ёнитов ({unitList.Count}) больше, чем UnitView ({unitViews.Count}) Ч часть юнитов не отобразитс€");
            }

            for (int i = 0; i < unitList.Count && i < unitViews.Count; i++)
            {
                var unit = unitList[i];
                var view = unitViews[i];
                var unitData = unit.UnitData;

                view.SetIcon(unitData.Icon);
                view.SetStats($"{unit.Health} / {unit.AttackValue}");
                view.SetUnit(unit);

                _visualRegistry.AddToRegistry(unit, view);
            }
        }

    }  
}

