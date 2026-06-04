using UnityEngine;

namespace Game.Scripts.Effects
{
    [CreateAssetMenu(fileName = "Dark", menuName = "Game.Scripts/Effects/DarkEffect")]
    public class DarkEffectSO : EffectSO
    {
        void OnValidate()
        {
            Name = "Dark";
            IsInstant = true;
        }

        public override void Apply(GameObject carriage)
        {
            SpriteRenderer[] sprites = carriage.GetComponentsInChildren<SpriteRenderer>();

            foreach (SpriteRenderer sprite in sprites)
            {
                sprite.color = Color.black;
            }
        }
    }
}