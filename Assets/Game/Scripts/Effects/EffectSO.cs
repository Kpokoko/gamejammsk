using UnityEngine;

namespace Game.Scripts.Effects
{
    public abstract class EffectSO : ScriptableObject
    {
        public string Name;
        public bool IsInstant = true;
        public abstract void Apply(GameObject carriage);
    }
}