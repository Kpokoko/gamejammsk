using DG.Tweening;
using UnityEngine;

namespace Game.Scripts
{
    public class TurnstileDirectionVisualizer : MonoBehaviour
    {
        private bool _isReversed = false;

        public void Reverse()
        {
            _isReversed = !_isReversed;
            transform.DOBlendableRotateBy(new Vector3(0, 0, 180), 0.3f)
                .SetEase(Ease.InOutQuad);
            Debug.Log("Иконка турникета развёрнута!");
        }
    }
}