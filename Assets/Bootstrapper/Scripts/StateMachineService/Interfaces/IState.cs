

namespace Services.GameStateMachine
{
    public interface IState : IExitableState
    {
        void Enter();
    }

    public interface IExitableState
    {
        void Exit();
    }

    public interface IPlayloadedState<TPlayLoad> : IExitableState
    {
        void Enter(TPlayLoad playLoad);
    }

}
