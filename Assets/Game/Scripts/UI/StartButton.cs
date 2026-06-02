using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.UI
{
    public class StartButton : MonoBehaviour
    {
        public void OnClick()
        {
            SceneManager.LoadScene("Game");
        }
    }
}