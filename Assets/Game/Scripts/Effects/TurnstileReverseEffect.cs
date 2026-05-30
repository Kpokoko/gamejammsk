using System;
using UnityEngine;

namespace Game.Scripts.Effects
{
    public class TurnstileReverseEffect : EffectSO
    {
        void OnValidate()
        {
            IsInstant = false;
        }

        public override void Apply(GameObject carriage)
        {
            return;
        }
    }
}