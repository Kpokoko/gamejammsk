using UnityEngine;

namespace Game.Scripts
{
    public class TurnstileController : MonoBehaviour
    {
        public MoveDirection PassDirection;

        public void Reverse()
        {
            PassDirection = PassDirection == MoveDirection.Left ? MoveDirection.Right : MoveDirection.Left;
        }
    }
}