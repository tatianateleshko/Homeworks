using Cysharp.Threading.Tasks;

namespace UI
{
    public interface IUnitsViewPresenter
    {
        void ShowUnits();
        void Register(UnitsWindow unitsWindow);

    }
}