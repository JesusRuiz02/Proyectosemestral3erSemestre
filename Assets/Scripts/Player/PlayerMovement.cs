using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string FLOOR_TAG = "Floor";
    private const string MOVING_FLOOR_TAG = "MovingFloor";
    private const string DOUBLE_JUMP = "DoubleJump";
    private bool _facingRight = true;
    private float _velocityX = default;
    [SerializeField] private float _speed = 3;
    private float _velocityY = default;
    [SerializeField] private float _jumpHeight = default;
    private Rigidbody2D _rigidbody2D = null;
    [SerializeField] private int _jumps = 2;
    [SerializeField] private int _basejumps = 2;
    private Animator _animator;
  

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DirectionCharacter();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoubleJump();
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void DirectionCharacter()
    {
        if (_rigidbody2D.velocity.x > 0 && !_facingRight)
        {
            Flip();
        }

        if (_rigidbody2D.velocity.x < 0 && _facingRight)
        {
            Flip();
        }
    }


    private void DoubleJump()
    {
        if (_jumps > 0)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpHeight);
            _jumps--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == FLOOR_TAG || collider.gameObject.tag == MOVING_FLOOR_TAG)
        {
            _jumps = _basejumps;
        }
        if (collider.gameObject.tag==DOUBLE_JUMP)
        {
            _basejumps = 2;
        }
    }
    
    private void Movement()
    {
        _velocityX = Input.GetAxisRaw("Horizontal");
        _velocityY = _rigidbody2D.velocity.y;
        _rigidbody2D.velocity = new Vector2(_velocityX * _speed, _velocityY);
        if (_velocityX!=0) _animator.SetBool("Run", true);
        else _animator.SetBool("Run",false);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
