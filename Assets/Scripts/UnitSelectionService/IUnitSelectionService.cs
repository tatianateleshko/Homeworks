using UnityEngine;

public interface IUnitSelectionService
{
    void SetUnitSelected(IUnit unit);
    IUnit GetSelectedUnit();
}
