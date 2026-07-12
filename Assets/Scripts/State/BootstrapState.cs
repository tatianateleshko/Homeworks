using Services.GameStateMachine;
using UnityEngine;
using UnityEngine.Rendering;

namespace GameStates
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IConfigDataService _configDataService;
        public BootstrapState(IGameStateMachine gameStateMachine, IConfigDataService configDataService)
        {
            _gameStateMachine = gameStateMachine;
            _configDataService = configDataService;
        }   
            
        public void Enter()
        {
            _configDataService.WarmUp();
            _gameStateMachine.Enter<LoadLevelState, string>("1");
        }

        public void Exit()
        {
        
        }
    }

}
