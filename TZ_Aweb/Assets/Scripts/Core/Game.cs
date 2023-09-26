using Core.Loading;
using Core.States;
using Services;
using Services.Data;

namespace Core
{
    public class Game
    {
        private readonly GameStateMachine _gameStateMachine;

        public IGameStateMachine StateMachine =>
            _gameStateMachine;

        public Game(ICoroutineRunner coroutineRunner, ILevelData levelData, LoadingCurtain loadingCurtain)
        {
            var serviceLocator = ServiceLocator.Container;
            serviceLocator.Restart();
            BindLevelData(levelData, serviceLocator);
            _gameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), serviceLocator, loadingCurtain);
            BindGameStateMachine(serviceLocator);
        }

        private void BindGameStateMachine(ServiceLocator serviceLocator) => 
            serviceLocator.RegisterService<IGameStateMachine>(_gameStateMachine);

        private void BindLevelData(ILevelData levelData, ServiceLocator serviceLocator) => 
            serviceLocator.RegisterService<ILevelData>(levelData);
    }
}