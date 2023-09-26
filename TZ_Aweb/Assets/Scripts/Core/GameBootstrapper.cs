using Core.Loading;
using Core.States;
using Services.Data;
using UnityEngine;

namespace Core
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;
        [SerializeField] private LevelData _levelData;
        
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, _levelData, _loadingCurtain);
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}