namespace Services.GameStateMachine
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPlayload>(TPlayload playload) 
        where TState : class, IPlayloadedState<TPlayload>;
    }

}
