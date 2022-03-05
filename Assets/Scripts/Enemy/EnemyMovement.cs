using System;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyMovement : MonoBehaviour
{
    private float _speed = default;
    private Rigidbody2D _rigidbody2D;
    
    [SerializeField] private bool _isStatic = default;
    [SerializeField] private bool _isWalker = default;
    [SerializeField] private bool _walksRight = default;
    
    [SerializeField] private Transform _wallCheck, _pitCheck, _groundCheck;
    [SerializeField] private bool _wallDetected, _pitDetected;
    [FormerlySerializedAs("_groundDetected")] [SerializeField] private bool _isGrounded;
    [SerializeField] private float _detectionRadius = default;
    [SerializeField] private LayerMask _whatIsGround;
    void Start()    
    {
        _speed = GetComponent<Enemy>()._speed;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        _pitDetected = !Physics2D.OverlapCircle(_pitCheck.position, _detectionRadius, _whatIsGround);
        _wallDetected =Physics2D.OverlapCircle(_wallCheck.position, _detectionRadius, _whatIsGround);
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _detectionRadius, _whatIsGround);
        if ((_pitDetected  || _wallDetected) && _isGrounded)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if (_isStatic)
        {
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (_isWalker)
        {
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (!_walksRight)
            {
                _rigidbody2D.velocity = new Vector2(-_speed * Time.deltaTime, _rigidbody2D.velocity.y);
            }
            else
            {
                _rigidbody2D.velocity = new Vector2(_speed * Time.deltaTime, _rigidbody2D.velocity.y);
            }  
        }
    }

    private void Flip()
    {
        _walksRight = !_walksRight;
        transform.localScale *= new Vector2(-1, transform.localScale.y);
    }
}
 

