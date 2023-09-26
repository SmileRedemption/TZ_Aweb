using System;
using System.Collections;
using Core.States;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Menu
{
    public class MenuUI : MonoBehaviour, IMenuUI
    {
        [SerializeField] private Button _gameButton;
        [SerializeField] private CanvasGroup _canvasGroup;

        public void OnGameButtonClick(Action onButtonClick) => 
            _gameButton.onClick.AddListener(() => onButtonClick?.Invoke());

        private void OnDisable() => 
            _gameButton.onClick.RemoveAllListeners();

        public void StartFadeIn() => 
            StartCoroutine(DoFadeIn());

        private IEnumerator DoFadeIn()
        {
            while (Math.Abs(_canvasGroup.alpha - 1) > 0.03f)
            {
                _canvasGroup.alpha += 0.1f;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}