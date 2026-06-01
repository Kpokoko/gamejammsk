using UnityEngine;

namespace Game.Scripts.Triggers
{
    public class TurnstileButton : Button
    {
        private int _prevCurrIndex;
        
        void Start()
        {
            G.CarriageManager.OnCarriageChanged += _ => _prevCurrIndex = -1;
        }
        
        public override void Init(GameObject go)
        {
            
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            var currCarriage = G.CarriageManager.CurrentIndex;
            if (currCarriage != _prevCurrIndex)
            {
                Debug.Log("Разворот турникетов");
                _prevCurrIndex = currCarriage;
                G.TriggeredEffectsController.ReverseAll();
            }
        }
    }
}