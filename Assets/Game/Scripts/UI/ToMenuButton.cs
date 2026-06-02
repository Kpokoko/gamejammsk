using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.UI
{
    public class ToMenuButton : MonoBehaviour
    {
        public void OnClick()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}