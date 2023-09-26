using Core;
using Core.States;
using Logic.Core.Player;
using Services.Inputs;
using UnityEngine;

namespace UI
{
    public class UIPresenter
    {
        private readonly IInputSource _inputSource;
        private readonly IPlayerCollider _playerCollider;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameStateMachine _stateMachine;

        private readonly UIView _uiView;
        
        public UIPresenter(IInputSource inputSource, IPlayerCollider playerCollider, UIView uiView, ISceneLoader sceneLoader, IGameStateMachine stateMachine)
        {
            _inputSource = inputSource;
            _playerCollider = playerCollider;
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;

            _uiView = uiView;
            
            _uiView.gameObject.SetActive(true);
        }

        public void Enable()
        {
            _uiView.OnButtonClick += OnButtonClick;
            _playerCollider.CollidedWithSurface += OnCollidedWith;
        }

        public void Disable()
        {
            _uiView.OnButtonClick -= OnButtonClick;
            _playerCollider.CollidedWithSurface -= OnCollidedWith;
        }
        
        private void OnCollidedWith() => 
            _uiView.PlayerOnCollided(RestartGame);

        private void RestartGame()
        {
            _stateMachine.Enter<LoadLevelState, string>("GameScene");
            Time.timeScale = 1;
        }

        private void OnButtonClick() => 
            _inputSource.OnButtonClick();
    }
}