using UnityEngine;

namespace Game.Scripts.Triggers
{
    public class PortalTrigger : Trigger
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (G.CarriageManager.IsTeleporting)
                {
                    G.CarriageManager.IsTeleporting = false;
                    return;
                }
                G.CarriageManager.TeleportToNearestPortal();
            }
        }
    }
}