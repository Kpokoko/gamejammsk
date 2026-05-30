using UnityEngine;

namespace Game.Scripts.Triggers
{
    public abstract class Button : MonoBehaviour
    {
        public ButtonType Type;

        public abstract void Init(GameObject go);
    }

    public enum ButtonType
    {
        Door,
        Turnstile
    }
}