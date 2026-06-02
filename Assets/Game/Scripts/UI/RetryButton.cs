using Game.Scripts.Infra;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.UI
{
    public class RetryButton : MonoBehaviour
    {
        public GameObject Pause;
        
        public void OnButtonClick()
        {
            G.LevelFlowController.IsSystemPaused = false;
            if (G.LevelFlowController.CurrentPhase is not LevelPhase.Edit)
                G.LevelFlowController.Resume();
            Pause.SetActive(false);
            
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}