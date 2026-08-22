using Code.Infrastructure.Services.EventBus;
using Zenject;

namespace UI
{
    public class UnitsViewSystem : IInitializable
    {
        private  IUnitsViewPresenter  _presenter;
        private IEventBus _eventBus;
        public UnitsViewSystem(IUnitsViewPresenter presenter, IEventBus eventBus)
        {
            _presenter = presenter;
            _eventBus = eventBus;
        }
        
        public void Initialize()
        {
           //_eventBus.Subscribe<PlayerViewSelectedSignal>( _presenter.)
            _presenter.ShowUnits();
        }

        public void PlayAttackAnim()
        {

        }
    }
}

