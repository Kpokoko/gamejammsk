using UnityEngine;

namespace Game.Scripts.Effects
{
    public abstract class EffectSO : ScriptableObject
    {
        public string Name;
        public bool IsInstant = false;
        public abstract void Apply(GameObject carriage);
    }
}