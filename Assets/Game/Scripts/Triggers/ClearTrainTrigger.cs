using UnityEngine;

namespace Game.Scripts.Triggers
{
    public class ClearTrainTrigger : Trigger
    {
        private int _count;
        public bool IsActive;
        
        public void Init(CarriageBorderType borderType, int count)
        {
            base.Init(borderType);
            _count = count;
            IsActive = true;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!IsActive)
                return;
            G.CarriageManager.ClearTrain(_count);
            G.LevelFlowController.ResetCameraZoom();
        }
    }
}