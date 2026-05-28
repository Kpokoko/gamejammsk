using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public MoveDirection MoveDirection = MoveDirection.Right;
    public float MoveSpeed;
    
    private bool _isMoving;

    public Action OnGameplayStop;
    public Action OnGameplayResume;
    
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _isMoving = true;
        OnGameplayStop += Stop;
        OnGameplayResume += Resume;
    }

    void Resume()
    {
        _isMoving = true;
    }

    void Stop()
    {
        _isMoving = false;
        _rigidbody.linearVelocity = Vector2.zero;
    }
    
    void FixedUpdate()
    {
        if (!_isMoving)
            return;
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
