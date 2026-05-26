using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class CarriageManager
    {
        private List<Transform> _carriages;
        private int _currIndex = 1;
        
        public event Action<int> OnCarriageChanged;
        
        public int CurrentIndex => _currIndex;
        public Transform CurrentCarriage => _carriages[_currIndex];

        public CarriageManager(List<Transform> carriages)
        {
            _carriages = carriages;
        }
        
        public Transform GetCarriage(int index) => _carriages[index];

        public void SetCurrent(int index)
        {
            --index;
            if (index < 0 || index >= _carriages.Count) return;
            
            Debug.Log($"Камера смотрит на вагон номер {index}");
            _currIndex = index;
            OnCarriageChanged?.Invoke(index);
        }
    }
}
