using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class CarriageManager
    {
        private List<Transform> _carriages;
        private int _currIndex = 1;
        private List<Transform> _nextCarriages;
        
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
            if (index < 0 || index >= _carriages.Count) return;
            
            _currIndex = index;
            OnCarriageChanged?.Invoke(index);
        }

        public void Swap(int index1, int index2)
        {
            (_carriages[index1], _carriages[index2]) = (_carriages[index2], _carriages[index1]);
        }

        public void ClearTrain(int count)
        {
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
            OnCarriageChanged?.Invoke(_currIndex + 1);
        }
    }
}
