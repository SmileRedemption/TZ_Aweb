using System;
using System.Collections;
using UnityEngine;

namespace Core.Loading
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _curtain;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show(Action onFadeOver)
        {
            gameObject.SetActive(true);
            _curtain.alpha = 1;
            StartCoroutine(DoFadeIn(onFadeOver));
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private IEnumerator DoFadeIn(Action onFadeOver)
        {
            while (_curtain.alpha > 0.5f)
            {
                _curtain.alpha -= 0.03f;
                yield return new WaitForSeconds(0.03f);
            }
            
            onFadeOver?.Invoke();
        }
    }
}