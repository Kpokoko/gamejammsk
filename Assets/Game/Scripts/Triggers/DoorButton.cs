using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Scripts.Triggers
{
    public class DoorButton : Button
    {
        private GameObject _door;


        [SerializeField] private AudioSource clickSound;


        public override void Init(GameObject door)
        {
            _door = door;
        }

        private void PlayButtonClick()
        {
            if (clickSound != null)
                clickSound.Play();
        }

        void OnTriggerEnter2D(Collider2D other) // #TODO Анимация открытия двери и прожатия кнопки.
        {
            _door.SetActive(false);
            gameObject.SetActive(false);
            PlayButtonClick();
        }
    }
}