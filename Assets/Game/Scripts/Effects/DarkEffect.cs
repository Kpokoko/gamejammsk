using UnityEngine;

namespace Game.Scripts.Effects
{
    [CreateAssetMenu(fileName = "Dark", menuName = "Game.Scripts/Effects/DarkEffect")]
    public class DarkEffectSO : EffectSO
    {
        [Range(0f, 1f)]
        [SerializeField] private float darg = 0.5f;

        void OnValidate()
        {
            Name = "Dark";
            IsInstant = true;
        }

        public override void Apply(GameObject carriage)
        {
            var renders = carriage.GetComponentsInChildren<SpriteRenderer>();

            Color darkColor = new Color(darg, darg, darg, 1f);

            foreach (var r in renders)
            {
                r.color = darkColor;
            }
        }
    }
}