using System;
using Game.Scripts;
using NUnit.Framework;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer hero_sprite;
    [SerializeField] private Animator animator;

    public MoveDirection MoveDirection = MoveDirection.Right;
    public float MoveSpeed;
    
    private bool _isMoving;

    public Action OnGameplayStop;
    public Action OnGameplayResume;
    
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _isMoving = true;
        OnGameplayStop += Stop;
        OnGameplayResume += Resume;
    }

    private void Update()
    {
        animator.SetBool("move", _isMoving);
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
            Flip();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<TurnstileController>(out var turnstile))
        {
            if (turnstile.PassDirection != MoveDirection)
            {
                Flip();
            }
        }
    }
    
    void Flip()
    {
        _rigidbody.linearVelocity = Vector2.zero;
        MoveDirection =
            MoveDirection == MoveDirection.Left
                ? MoveDirection.Right
                : MoveDirection.Left;

        hero_sprite.flipX = MoveDirection == MoveDirection.Left;

    }
}

public enum MoveDirection
{
    Left,
    Right
}
