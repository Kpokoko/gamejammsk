using Game.Scripts.Infra;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class ContinueButton : MonoBehaviour
    {
        public GameObject Pause;
        
        public void OnButtonClick()
        {
            G.LevelFlowController.IsSystemPaused = false;
            if (G.LevelFlowController.CurrentPhase is not LevelPhase.Edit)
                G.LevelFlowController.Resume();
            Pause.SetActive(false);
        }
    }
}