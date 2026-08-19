using Zenject;

namespace UI
{
    public class UnitsViewSystem : IInitializable
    {
        private  IUnitsViewPresenter  _presenter;

        public UnitsViewSystem(IUnitsViewPresenter presenter)
        {
            _presenter = presenter;
        }
        
        public void Initialize()
        {
            _presenter.ShowUnits();
        }
    }
}

