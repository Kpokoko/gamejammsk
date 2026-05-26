using DG.Tweening;
using UnityEngine;

namespace Game.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float transitionDuration = 0.5f;

        void Start()
        {
            Debug.Log($"CameraController Start, CarriageManager: {G.CarriageManager}");
            G.CarriageManager.OnCarriageChanged += OnCarriageChanged;
        }
        void OnCarriageChanged(int index)
        {
            Debug.Log($"CameraController получил событие, индекс {index}");
            var target = G.CarriageManager.GetCarriage(index).position;
            Debug.Log($"Цель камеры: {target}, текущая позиция: {transform.position}");
            transform.DOMoveX(target.x, transitionDuration).SetEase(Ease.InOutQuad);
        }
    }
}