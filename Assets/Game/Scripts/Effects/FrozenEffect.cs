using UnityEngine;

namespace Game.Scripts.Effects
{
    [CreateAssetMenu(fileName = "Frozen", menuName = "Game.Scripts/Effects/FrozenEffect")]
    public class FrozenEffectSO : EffectSO
    {
        void OnValidate()
        {
            IsInstant = false;
        }
        
        public override void Apply(GameObject carriage)
        {
            carriage.GetComponent<Carriage>().IsStable = true;
        }
    }
}