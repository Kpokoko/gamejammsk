using UnityEngine;

namespace Game.Scripts.Triggers
{
    public class DoorButton : Button
    {
        private GameObject _door;
        
        public override void Init(GameObject door)
        {
            _door = door;
        }

        void OnTriggerEnter2D(Collider2D other) // #TODO Анимация открытия двери и прожатия кнопки.
        {
            _door.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}