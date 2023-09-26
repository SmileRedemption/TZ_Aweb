using Core.Factories;
using Logic.CameraLogic;
using Logic.Core.Player;
using Services.Data;
using Services.Inputs;
using UnityEngine;

namespace Core.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IInputSource _inputSource;
        private readonly IPlayerFactory _playerFactory;
        private readonly IPlayerCollider _playerCollider;
        private readonly ILevelData _levelData;
        
        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader,IInputSource inputSource, IPlayerFactory playerFactory, IPlayerCollider playerCollider, ILevelData levelData)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _inputSource = inputSource;
            _playerFactory = playerFactory;
            _playerCollider = playerCollider;
            _levelData = levelData;
        }

        public void Enter(string sceneName) => 
            _sceneLoader.Load(sceneName, OnLoaded);

        public void Exit()
        {
            
        }

        private void OnLoaded()
        {
            CreatePLayer();
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void CreatePLayer()
        {
            var hero = _playerFactory.CreatePlayer(_levelData.InitialPlayerPosition);
            hero.Initialize(_inputSource, _levelData);
            FollowPlayer(hero.transform);
        }

        private void FollowPlayer(Transform playerTransform)
        {
            var camera = Camera.main;
            if (camera != null)
                camera
                    .GetComponent<CameraFollow>()
                    .Follow(playerTransform);
        }
    }
}