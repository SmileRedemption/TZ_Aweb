using System;
using System.Collections;
using Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public void Load(string name, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));

        private IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);
            
            while (!waitNextScene.isDone)
                yield return null;
            
            onLoaded?.Invoke();
        }
    }

    public interface ISceneLoader : IService
    {
        void Load(string name, Action onLoaded = null);
    }

    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator corountine);
    }
}