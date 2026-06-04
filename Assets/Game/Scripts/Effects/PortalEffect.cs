using UnityEngine;

namespace Game.Scripts.Effects
{
    [CreateAssetMenu(fileName = "Portal", menuName = "Game.Scripts/Effects/PortalEffect")]
    public class PortalEffect : EffectSO
    {
        public MoveDirection Side;
        
        void OnValidate()
        {
            Name = "Portal";
            IsInstant = false;
        }
        
        public override void Apply(GameObject carriage)
        {
        }
    }
}