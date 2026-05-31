using UnityEngine;

namespace Game.Scripts.Triggers
{
    public class TurnstileButton : Button
    {
        public override void Init(GameObject go)
        {
            
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Разворот турникетов");
            G.TriggeredEffectsController.ReverseAll();
        }
    }
}