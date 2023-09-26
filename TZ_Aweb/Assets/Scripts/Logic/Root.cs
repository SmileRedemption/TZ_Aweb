using System;
using Core;
using Core.States;
using Logic.Core.Player;
using Services;
using Services.Inputs;
using UI;
using UnityEngine;

namespace Logic
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private UIView _uiView;

        private UIPresenter _uiPresenter;
        
        private void Start()
        {
            _uiPresenter = new UIPresenter(ServiceLocator.Container.GetService<IInputSource>(),
                ServiceLocator.Container.GetService<IPlayerCollider>(), 
                _uiView, 
                ServiceLocator.Container.GetService<ISceneLoader>(),
                ServiceLocator.Container.GetService<IGameStateMachine>());
            _uiPresenter.Enable();
        }
        
        private void OnDestroy() => 
            _uiPresenter.Disable();
    }
}