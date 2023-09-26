using System;
using System.Collections;
using Logic.Core.PoolOfObject.Cube;
using Logic.Core.PoolOfObject.TrackPool;
using UI.View;
using UnityEngine;

namespace UI
{
    public class UIView : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private StartGameScreen _startGameScreen;

        [SerializeField] private EndGameScreen _endGameScreen;

        [Header("Wait For Start Game")] 
        [SerializeField] private TrackSpawner _trackSpawner;

        [SerializeField] private GameObject _warpEffect;
        [SerializeField] private CubeForPickupPool _cubeForPickupPool;

        public event Action OnButtonClick;

        private void Start() => 
            StartCoroutine(WaitingToPutFingerOnScreen());

        private IEnumerator WaitingToPutFingerOnScreen()
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            StartGame();
        }

        private void StartGame()
        {
            _trackSpawner.gameObject.SetActive(true);
            _cubeForPickupPool.gameObject.SetActive(true);
            _warpEffect.gameObject.SetActive(true);
            OnButtonClick?.Invoke();

            _startGameScreen.Hide();        
        }
        
        public void PlayerOnCollided(Action onRestartGame) => 
            StopGame(onRestartGame);
        
        private void StopGame(Action onRestartGame)
        {
            _endGameScreen.Show(() => onRestartGame?.Invoke());
            Time.timeScale = 0;
        }
    }
}