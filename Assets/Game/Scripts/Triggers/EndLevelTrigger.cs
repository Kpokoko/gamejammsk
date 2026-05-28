using Game.Scripts.Infra;
using UnityEngine;

namespace Game.Scripts.Triggers
{
    public class EndLevelTrigger : Trigger
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (BorderType is CarriageBorderType.EndLevelTrigger)
            {
                G.LevelFlowController.FinishLevel();
            }
        }
    }
}