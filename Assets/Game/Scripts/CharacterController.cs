using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public MoveDirection MoveDirection;
    public float MoveSpeed;
    
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        if (MoveDirection is MoveDirection.Left)
            _rigidbody.linearVelocity = MoveSpeed * Vector2.left;
        else
            _rigidbody.linearVelocity = MoveSpeed * Vector2.right;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            _rigidbody.linearVelocity = Vector2.zero;
            MoveDirection =
                MoveDirection == MoveDirection.Left
                    ? MoveDirection.Right
                    : MoveDirection.Left;
        }
    }
}

public enum MoveDirection
{
    Left,
    Right
}
