using DG.Tweening;
using UnityEngine;

namespace Game.Scripts
{
    public class CameraController : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private float defaultSize = 5f;
        [SerializeField] private float zoomedSize = 2f;
        [SerializeField] private float transitionDuration = 0.5f;

        void Start()
        {
            _camera = GetComponent<Camera>();
            G.CarriageManager.OnCarriageChanged += OnCarriageChanged;
            G.LevelFlowController.OnZoom += Zoom;
            G.LevelFlowController.OnZoomReset += ResetZoom;
        }
        void OnCarriageChanged(int index)
        {
            var target = G.CarriageManager.GetCarriage(index).position;
            transform.DOMoveX(target.x, transitionDuration).SetEase(Ease.InOutQuad);
        }

        public void Zoom()
        {
            _camera.DOOrthoSize(zoomedSize, transitionDuration).SetEase(Ease.InOutQuad);
        }

        public void ResetZoom()
        {
            _camera.DOOrthoSize(defaultSize, transitionDuration).SetEase(Ease.InOutQuad);
        }
    }
}