using System;
using System.Collections.Generic;
using Core.Factories;
using Core.Loading;
using Logic.Core.Player;
using Services;
using Services.Data;
using Services.Inputs;

namespace Core.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly IDictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, ServiceLocator serviceLocator, LoadingCurtain loadingCurtain)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, serviceLocator, loadingCurtain),
                [typeof(MenuState)] = new MenuState(this, sceneLoader, serviceLocator),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader,
                    serviceLocator.GetService<IInputSource>(), serviceLocator.GetService<IPlayerFactory>(),
                    serviceLocator.GetService<IPlayerCollider>(), serviceLocator.GetService<ILevelData>()),
                [typeof(GameLoopState)] = new GameLoopState(this)
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }
        
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            var state = GetState<TState>();
            _activeState = state;
            return state;
        }
        
        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}