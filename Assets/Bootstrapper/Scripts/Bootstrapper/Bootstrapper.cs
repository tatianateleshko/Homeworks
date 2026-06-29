using GameStates;
using Services.GameStateMachine;
using Zenject;


namespace Services.Bootstrapper
{
    public class Bootstrapper : IInitializable
    {
        private readonly IGameStateMachine _stateMachine;

        public Bootstrapper(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            _stateMachine.Enter<BootstrapState>();
        }
    }

}
