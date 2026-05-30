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
        [SerializeField] private float editZoomSize = 10f;

        private float _baseY; // Y камеры в "домашнем" состоянии

        void Start()
        {
            _camera = GetComponent<Camera>();
            _baseY = transform.position.y;

            G.CarriageManager.OnCarriageChanged += OnCarriageChanged;
            G.LevelFlowController.OnZoom += Zoom;
            G.LevelFlowController.OnZoomReset += ResetZoom;
            G.LevelFlowController.OnEditZoom += ZoomEdit;
            G.LevelFlowController.OnEditZoomReset += ResetZoomEdit;
        }

        void OnCarriageChanged(int index)
        {
            var target = G.CarriageManager.GetCarriage(index).position;
            transform.DOMoveX(target.x, transitionDuration).SetEase(Ease.InOutQuad);
        }

        public void Zoom()
        {
            _camera.DOKill();
            _camera.DOOrthoSize(zoomedSize, transitionDuration).SetEase(Ease.InOutQuad);
        }

        public void ResetZoom()
        {
            _camera.DOOrthoSize(defaultSize, transitionDuration).SetEase(Ease.InOutQuad);
        }

        public void ZoomEdit()
        {
            var targetY = _baseY + (editZoomSize - defaultSize);
            _camera.DOOrthoSize(editZoomSize, transitionDuration).SetEase(Ease.InOutQuad).SetUpdate(true);
            transform.DOMoveY(targetY, transitionDuration).SetEase(Ease.InOutQuad).SetUpdate(true);
        }

        public void ResetZoomEdit()
        {
            _camera.DOOrthoSize(defaultSize, transitionDuration).SetEase(Ease.InOutQuad).SetUpdate(true);
            transform.DOMoveY(_baseY, transitionDuration).SetEase(Ease.InOutQuad).SetUpdate(true);
        }
    }
}