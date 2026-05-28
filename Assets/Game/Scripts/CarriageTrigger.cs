using UnityEngine;

namespace Game.Scripts
{
    public class CarriageTrigger : Trigger
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            G.CarriageManager.SetCurrent(Carriage.Number);
        }
    }

    public enum CarriageBorderType
    {
        TransitionTrigger,
        Wall,
        DialoguePosTrigger
    }
}