using Core.Menu;
using Services;

namespace Core.States
{
    public class MenuState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly ServiceLocator _serviceLocator;

        public MenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, ServiceLocator serviceLocator)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _serviceLocator = serviceLocator;
        }

        public void Enter(string payload) => 
            _serviceLocator.GetService<IMenuUI>().OnGameButtonClick(EnterLoadLevelState);

        private void EnterLoadLevelState() => 
            _gameStateMachine.Enter<LoadLevelState, string>(SceneName.GameScene);

        public void Exit()
        {
            
        }
        
    }
}