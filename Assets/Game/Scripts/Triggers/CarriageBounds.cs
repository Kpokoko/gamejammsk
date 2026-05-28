using UnityEngine;

namespace Game.Scripts.Triggers
{
    public class CarriageBounds : Trigger
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            G.CarriageManager.SetCurrent(Carriage.Number);
        }
    }
}