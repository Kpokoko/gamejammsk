using UnityEngine;

namespace Game.Scripts
{
    public class TurnstileController : MonoBehaviour
    {
        public MoveDirection PassDirection;

        public void Reverse()
        {
            Debug.Log($"Старое направление: {PassDirection}");
            PassDirection = PassDirection == MoveDirection.Left ? MoveDirection.Right : MoveDirection.Left;
            Debug.Log($"Новое направление: {PassDirection}");
        }
    }
}