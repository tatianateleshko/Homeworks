using Services.GameStateMachine;
using UnityEngine;

namespace GameStates
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        public BootstrapState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;   
        }

        public void Enter()
        {
            _gameStateMachine.Enter<LoadLevelState, string>("1");
        }

        public void Exit()
        {
        
        }
    }

}
