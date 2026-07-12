using Services.GameStateMachine;
using Services.SceneLoader;


namespace GameStates
{
    public class LoadLevelState : IPlayloadedState<string>
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        public LoadLevelState(IGameStateMachine stateMachine,
            ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string playLoad)
        {
            _sceneLoader.Load(playLoad);
        }

        public void Exit()
        {
           
        }
    }

}
