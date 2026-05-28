using Game.Scripts.Infra;
using UnityEngine;

namespace Game.Scripts
{
    public abstract class Trigger : MonoBehaviour
    {
        public BoxCollider2D BoxCollider;
        public Carriage Carriage;
        public CarriageBorderType BorderType;
        
        public virtual void Init(CarriageBorderType borderType)
        {
            BorderType = borderType;
            BoxCollider = GetComponent<BoxCollider2D>();
            if (borderType is CarriageBorderType.TransitionTrigger
                || borderType is CarriageBorderType.DialoguePosTrigger)
                BoxCollider.isTrigger = true;
            if (borderType is CarriageBorderType.Wall)
                BoxCollider.isTrigger = false;

            Carriage = GetComponentInParent<Carriage>();
        }
    }
}