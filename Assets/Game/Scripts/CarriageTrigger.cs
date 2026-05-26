using UnityEngine;

namespace Game.Scripts
{
    public class CarriageBorder : MonoBehaviour
    {
        public BoxCollider2D BoxCollider;
        public Carriage Carriage;

        public void Init(CarriageBorderType borderType)
        {
            BoxCollider = GetComponent<BoxCollider2D>();
            if (borderType is CarriageBorderType.Trigger)
                BoxCollider.isTrigger = true;
            else
                BoxCollider.isTrigger = false;
            Carriage = GetComponentInParent<Carriage>();
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            G.CarriageManager.SetCurrent(Carriage.Number);
        }
    }

    public enum CarriageBorderType
    {
        Trigger,
        Wall
    }
}