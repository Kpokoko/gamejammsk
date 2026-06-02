using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.UI
{
    public class CloseGameButton : MonoBehaviour
    {
        public void OnClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}