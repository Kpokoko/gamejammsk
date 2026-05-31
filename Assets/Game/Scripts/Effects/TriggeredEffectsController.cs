using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Effects
{
    public class TriggeredEffectsController
    {
        private List<TurnstileController> _turnstiles = new List<TurnstileController>();
        private List<TurnstileDirectionVisualizer> _visual = new List<TurnstileDirectionVisualizer>();

        public void RegisterTurnstile(TurnstileController turnstile)
        {
            Debug.Log($"Зарегистрирован турникет: {turnstile.gameObject.name}");
            _turnstiles.Add(turnstile);
        }

        public void RegisterTurnstileVis(TurnstileDirectionVisualizer visualizer) => _visual.Add(visualizer);

        public void ReverseAll()
        {
            foreach (var t in _turnstiles)
                t.Reverse();
            foreach (var v in _visual)
                v.Reverse();
        }
    }
}