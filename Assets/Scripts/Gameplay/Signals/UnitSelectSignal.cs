namespace Code.Gameplay.Signals
{
    public struct UnitSelectSignal
    {
        public IUnit SelectedUnit;
        
        public UnitSelectSignal(IUnit selectedUnit)
        {
            SelectedUnit = selectedUnit;
        }
    }
}