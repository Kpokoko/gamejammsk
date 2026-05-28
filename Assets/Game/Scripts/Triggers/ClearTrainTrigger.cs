using UnityEngine;

namespace Game.Scripts.Triggers
{
    public class ClearTrainTrigger : Trigger
    {
        private int _count;
        
        public void Init(CarriageBorderType borderType, int count)
        {
            base.Init(borderType);
            _count = count;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            G.CarriageManager.ClearTrain(_count);
            G.LevelFlowController.ResetCameraZoom();
        }
    }
}