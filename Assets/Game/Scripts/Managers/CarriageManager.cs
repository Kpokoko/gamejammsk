using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Triggers;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Game.Scripts.Managers
{
    public class CarriageManager
    {
        private List<Transform> _carriages;
        private int _currIndex = 1;
        private List<Transform> _nextCarriages;

        public bool IsTeleporting;
        public event Action<int> OnCarriageChanged;
        
        public int CurrentIndex => _currIndex;
        public Transform CurrentCarriage => _carriages[_currIndex];
        public int CarriageCount => _carriages.Count;

        public void ExtendTrain(Transform next) => _nextCarriages.Add(next);

        public CarriageManager(List<Transform> carriages)
        {
            _carriages = carriages;
            _nextCarriages = new List<Transform>();
        }
        
        public Transform GetCarriage(int index) => _carriages[index];

        public void SetCurrent(int index)
        {
            var total = _carriages.Count + _nextCarriages.Count;
            if (index < 0 || index >= total) return;
    
            if (index == _currIndex) return;
            
            if (index >= _carriages.Count)
            {
                _carriages.AddRange(_nextCarriages);
                _nextCarriages.Clear();
            }
    
            _currIndex = index;
            OnCarriageChanged?.Invoke(index);
        }

        public void Swap(int index1, int index2)
        {
            (_carriages[index1], _carriages[index2]) = (_carriages[index2], _carriages[index1]);
        }

        public void ClearTrain(int count)
        {
            Debug.LogWarning("Очистка");
            for (var i = 0; i < count; ++i)
            {
                UnityEngine.Object.Destroy(_carriages[i].gameObject);
            }
    
            _carriages = _carriages.Skip(count).ToList();
            _carriages.AddRange(_nextCarriages);
            _nextCarriages.Clear();
    
            for (var i = 0; i < _carriages.Count; ++i)
                _carriages[i].GetComponent<Carriage>().Number = i;
            
            _currIndex = Mathf.Max(0, _currIndex - count);
            OnCarriageChanged?.Invoke(_currIndex);
            _carriages[0].transform.Find("RightBorder")
                    ?.GetComponent<CarriageBounds>().Init(CarriageBorderType.Wall);
            Debug.LogWarning($"Длина поезда {_carriages.Count}");
        }

        public void TeleportToNearestPortal()
        {
            if (IsTeleporting) return;
            var bestIndex = -1;
            var bestDist = int.MaxValue;
            PortalTrigger bestPortal = null;

            for (var i = 0; i < _carriages.Count; i++)
            {
                if (i == _currIndex) continue;
        
                var carriage = _carriages[i].gameObject.GetComponent<Carriage>();
                if (!carriage || !carriage.HasPortal)
                    continue;

                var dist = Mathf.Abs(i - _currIndex);
                if (dist < bestDist)
                {
                    bestDist = dist;
                    bestIndex = i;
                    bestPortal = _carriages[i].gameObject.GetComponentInChildren<PortalTrigger>();
                }
                else if (dist == bestDist)
                {
                    var currentPortal = _carriages[_currIndex].gameObject.GetComponentInChildren<PortalTrigger>();
                    var candidatePortalL = _carriages[bestIndex].gameObject.GetComponentInChildren<PortalTrigger>();
                    var candidatePortalR = _carriages[i].gameObject.GetComponentInChildren<PortalTrigger>();

                    bool currentIsLeft = currentPortal != null && currentPortal.transform.localPosition.x < 0;
                    bool candidateLIsLeft = candidatePortalL != null && candidatePortalL.transform.localPosition.x < 0;
                    bool candidateRIsLeft = candidatePortalR != null && candidatePortalR.transform.localPosition.x < 0;

                    if ((!currentIsLeft && candidateRIsLeft) || (!currentIsLeft && candidateLIsLeft && !candidateRIsLeft))
                    {
                        bestIndex = i;
                        bestPortal = candidatePortalR;
                    }
                }
            }

            if (bestIndex == -1 || bestPortal == null) return;

            var col = bestPortal.GetComponent<Collider2D>();
            var targetPos = col != null
                ? new Vector3(col.bounds.center.x, col.bounds.min.y, _carriages[bestIndex].position.z)
                : bestPortal.transform.position;

            G.LevelFlowController.CharacterController.transform.position = targetPos;
            SetCurrent(bestIndex);
            IsTeleporting = true;
        }
    }
}
