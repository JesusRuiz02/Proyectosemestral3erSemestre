using System;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private const string FLOORTAG = "Floor";
    private const string MFLOORTAG = "Mfloor";
    private bool _facingRight = true;
    private float _velX = default;
    [SerializeField] private float _speed = 3;
    private float _velY = default;
    [SerializeField] private float _jumpHeight = default;
    private Rigidbody2D _rigidbody2D = null;
    [SerializeField] private int _jumps = 2;
    [SerializeField] private int _basejumps = 2;
    
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
        if (collider.gameObject.tag == FLOORTAG || collider.gameObject.tag == MFLOORTAG)
        {
            _jumps = _basejumps;
        }
    }

    private void Movement()
    {
        _velX = Input.GetAxis("Horizontal");
        _velY = _rigidbody2D.velocity.y;
        _rigidbody2D.velocity = new Vector2(_velX * _speed, _velY);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f,180f,0f);
    }
}

