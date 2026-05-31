using System;
using UnityEngine;

namespace Game.Scripts.Effects
{
    [CreateAssetMenu(fileName = "TurnstileReverse", menuName = "Game.Scripts/Effects/TurnstileReverseEffect")]
    public class TurnstileReverseEffect : EffectSO
    {
        public MoveDirection Side;
        
        void OnValidate()
        {
            Name = "TurnstileReverseEffect";
            IsInstant = false;
        }

        public override void Apply(GameObject carriage)
        {
            return;
        }
    }
}