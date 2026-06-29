using Services.StateFactory;
using System.Net.NetworkInformation;
using UnityEngine;

namespace Services.GameStateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly IStateFactory _stateFactory;
        private IExitableState _currentState;
        public GameStateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPlayload>(TPlayload playload) where TState : class, IPlayloadedState<TPlayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(playload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();
            TState state = GetState<TState>();
            _currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _stateFactory.GetState<TState>();

    }

}
