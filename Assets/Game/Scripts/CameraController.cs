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
        [SerializeField] private float followSmoothing = 0.1f;

        private float _baseY;
        private Transform _followTarget;
        private bool _isFollowing;
        private bool _transitionComplete; // Lerp активен только после завершения твина

        void Start()
        {
            _camera = GetComponent<Camera>();
            _baseY = transform.position.y;
            _followTarget = GameObject.FindGameObjectWithTag("Player").transform;

            G.CarriageManager.OnCarriageChanged += OnCarriageChanged;
            G.LevelFlowController.OnZoom += Zoom;
            G.LevelFlowController.OnZoomReset += ResetZoom;
            G.LevelFlowController.OnEditZoom += ZoomEdit;
            G.LevelFlowController.OnEditZoomReset += ResetZoomEdit;
        }

        void Update()
        {
            if (!_isFollowing || !_transitionComplete || _followTarget == null) return;

            var pos = transform.position;
            pos.x = Mathf.Lerp(pos.x, _followTarget.position.x, 1f - Mathf.Pow(followSmoothing, Time.deltaTime));
            transform.position = pos;
        }

        void OnCarriageChanged(int index)
        {
            if (_isFollowing) return;

            var target = G.CarriageManager.GetCarriage(index).position;
            transform.DOMoveX(target.x, transitionDuration).SetEase(Ease.InOutQuad);
        }

        public void Zoom()
        {
            Debug.Log($"[Camera] Zoom called. followTarget: {_followTarget?.name ?? "NULL"}");
    
            _isFollowing = true;
            _transitionComplete = false;

            transform.DOKill();
            _camera.DOKill();

            _camera.DOOrthoSize(zoomedSize, transitionDuration)
                .SetEase(Ease.InOutQuad)
                .OnStart(() => Debug.Log($"[Camera] OrthoSize tween started. Target: {zoomedSize}"))
                .OnComplete(() => Debug.Log($"[Camera] OrthoSize tween complete. Current: {_camera.orthographicSize}"));

            transform.DOMoveX(_followTarget.position.x, transitionDuration)
                .SetEase(Ease.InOutQuad)
                .OnStart(() => Debug.Log($"[Camera] MoveX tween started. Target: {_followTarget.position.x}, Current: {transform.position.x}"))
                .OnComplete(() =>
                {
                    Debug.Log("[Camera] MoveX tween complete");
                    _transitionComplete = true;
                });
        }

        public void ResetZoom()
        {
            _isFollowing = false;
            _transitionComplete = false;

            var carriageX = G.CarriageManager.GetCarriage(
                G.CarriageManager.CurrentIndex).position.x;

            transform.DOKill();
            transform.DOMoveX(carriageX, transitionDuration).SetEase(Ease.InOutQuad);
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