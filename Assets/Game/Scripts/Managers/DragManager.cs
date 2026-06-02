using DG.Tweening;
using Game.Scripts;
using Game.Scripts.Infra;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    private Carriage _dragged;
    private Vector3 _draggedFrom;
    private bool _isAnimating;
    
    void Update()
    {
        if (G.LevelFlowController.IsSystemPaused)
        {
            return;
        }

        if (G.LevelFlowController.CurrentPhase is LevelPhase.Gameplay && Input.GetMouseButtonDown(1))
        {
            G.LevelFlowController.EnterPhase(LevelPhase.Edit);
            G.LevelFlowController.Pause();
        }
        else if (G.LevelFlowController.CurrentPhase is LevelPhase.Edit && Input.GetMouseButtonDown(1))
        {
            G.LevelFlowController.EnterPhase(LevelPhase.Gameplay);
            G.LevelFlowController.Resume();
        }
        
        if (G.LevelFlowController.CurrentPhase is not LevelPhase.Edit)
            return;
        
        if (Input.GetMouseButtonDown(0))
        {
            if (_isAnimating) return;
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider is not null
                && hit.collider.TryGetComponent<Carriage>(out var carriage))
            {
                if (carriage.Number != 0
                    && Mathf.Abs(G.CarriageManager.CurrentIndex - carriage.Number) == 1
                    && !carriage.IsStable)
                {
                    _dragged = carriage;
                    _draggedFrom = carriage.transform.position;
                    _draggedFrom.z = 0;
                }
            }
        }

        if (_dragged is not null && Input.GetMouseButton(0))
        {
            var mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _dragged.transform.position = new Vector3(mouseWorld.x, mouseWorld.y, 0);
        }

        if (_dragged is not null && Input.GetMouseButtonUp(0))
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            var didSwapped = false;
            if (hit.collider is not null
                && hit.collider.TryGetComponent<Carriage>(out var target)
                && target != _dragged)
            {
                if (target.Number != 0
                    && Mathf.Abs(G.CarriageManager.CurrentIndex - target.Number) == 1
                    && !target.IsStable)
                {
                    SwapCarriages(_dragged, target);
                    didSwapped = true;
                }
            }

            if (!didSwapped)
            {
                _isAnimating = true;
                _dragged.transform.DOMove(_draggedFrom, 0.2f).SetEase(Ease.OutQuad).SetUpdate(true)
                    .OnComplete(() =>
                    {
                        Physics2D.SyncTransforms();
                        _isAnimating = false;
                        
                    });
            }

            _dragged = null;
        }
    }

    void SwapCarriages(Carriage from, Carriage to)
    {
        var posTo = to.transform.position;
        posTo.z = 0;
        var posFrom = new Vector3(_draggedFrom.x, _draggedFrom.y, 0);
        
        Debug.Log($"posFrom: {posFrom}, posTo: {posTo}");

        _isAnimating = true;
        from.transform.DOMove(posTo, 0.2f).SetEase(Ease.OutQuad).SetUpdate(true);
        to.transform.DOMove(posFrom, 0.2f).SetEase(Ease.OutQuad).SetUpdate(true)
            .OnComplete(() =>
            {
                Physics2D.SyncTransforms();
                _isAnimating = false;
                        
            });

        Debug.Log($"Swap: from.Number={from.Number}, to.Number={to.Number}, CurrentIndex={G.CarriageManager.CurrentIndex}");
        G.CarriageManager.Swap(from.Number, to.Number);
        (from.Number, to.Number) = (to.Number, from.Number);
        Debug.Log($"After swap: from.Number={from.Number}, to.Number={to.Number}");
    }
}
