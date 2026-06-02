using Game.Scripts.Infra;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class PauseSwitcher : MonoBehaviour
    {
        public GameObject Pause;
        
        public void OnButtonClick()
        {
            var active = Pause.activeSelf;
            if (active)
            {
                G.LevelFlowController.IsSystemPaused = false;
                if (G.LevelFlowController.CurrentPhase is not LevelPhase.Edit)
                    G.LevelFlowController.Resume();
                Pause.SetActive(false);
            }
            else
            {
                G.LevelFlowController.IsSystemPaused = true;
                G.LevelFlowController.Pause();
                Pause.SetActive(true);
            }
        }
    }
}