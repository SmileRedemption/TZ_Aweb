using UnityEngine;

namespace UI.View
{
    public class StartGameScreen : MonoBehaviour
    {
        public void Hide() => 
            gameObject.SetActive(false);

        public void Show() => 
            gameObject.SetActive(true);
    }
}