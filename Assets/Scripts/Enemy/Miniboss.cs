using UnityEngine;
using Random = UnityEngine.Random;

public class Miniboss : MonoBehaviour
{
    [Header("Idel")] 
    [SerializeField] private float _idelMoveSpeed = default;
    [SerializeField] private Vector2 _idelMoveDirection = default;
    
    [Header("AttackUpDown")]
    [SerializeField] private float _attackMoveSpeed = default;
    [SerializeField] private Vector2 _attackMoveDirection = default;

    [Header("AttackPlayer")] 
    [SerializeField] private float _attackPlayerSpeed = default;
    [SerializeField] private Transform _player = default;
    private Vector2 _playerPosition = default;
    private bool _hasPlayerPosition = false;

    [Header("Other")] 
    [SerializeField] private Transform _groundCheckUp = default;
    [SerializeField] private Transform _groundCheckDown = default;
    [SerializeField] private Transform _groundCheckWall = default;
    [SerializeField] private float _groundCheckRadius = default;
    [SerializeField] private LayerMask _groundLayer = default;
    [SerializeField] private bool _isTouchingDown = default;
    [SerializeField] private bool _isTouchingUp = default;
    [SerializeField] private bool _isTouchingWall = default;
    [SerializeField] private bool _isFacingLeft = true;
    [SerializeField] private bool _goingUp = true;
    [SerializeField] private Rigidbody2D _enemyRigidbody2D;
    private Animator enemyAnim;
    
    void Start()
    {
       _idelMoveDirection.Normalize();
       _attackMoveDirection.Normalize();
       _enemyRigidbody2D.GetComponent<Rigidbody2D>();
       enemyAnim = GetComponent<Animator>();
    }
    
    void Update()
    {
        _isTouchingUp = Physics2D.OverlapCircle(_groundCheckUp.position, _groundCheckRadius, _groundLayer);
        _isTouchingDown = Physics2D.OverlapCircle(_groundCheckDown.position, _groundCheckRadius, _groundLayer);
        _isTouchingWall = Physics2D.OverlapCircle(_groundCheckWall.position, _groundCheckRadius, _groundLayer); 
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(_groundCheckUp.position,_groundCheckRadius);
        Gizmos.DrawWireSphere(_groundCheckDown.position,_groundCheckRadius);
        Gizmos.DrawWireSphere(_groundCheckWall.position,_groundCheckRadius);
    }

    private void ChangeDirection()
    {
        _goingUp = !_goingUp;
        _idelMoveDirection.y *= -1;
        _attackMoveDirection.y *= -1;
    }
    public void IdelState()
    {
        if (_isTouchingUp && _goingUp)
        {
            ChangeDirection();
        }
        else if (_isTouchingDown && !_goingUp)
        {
            ChangeDirection();
        }
        if (_isTouchingWall)
        {
            if (_isFacingLeft)
            {
                Flip(); 
            }
            else if(!_isFacingLeft)
            {
                Flip();
            } 
        }
        _enemyRigidbody2D.velocity = _idelMoveSpeed * _idelMoveDirection;
    }
    public void AttackUpDoWN()
    {
        if (_isTouchingUp && _goingUp)
        {
            ChangeDirection();
        }
        else if (_isTouchingDown && !_goingUp)
        {
            ChangeDirection();
        }
        if (_isTouchingWall)
        {
            if (_isFacingLeft)
            {
                Flip(); 
            }
            else if(!_isFacingLeft)
            {
                Flip();
            }
        }
        _enemyRigidbody2D.velocity = _attackMoveSpeed * _attackMoveDirection;
    }
    void randomStatePicker()
    {
        int RandomStatePicker = Random.Range(0,2);
        if (RandomStatePicker == 0)
        {
           enemyAnim.SetTrigger("AttackUpDown"); 
        }
        else if (RandomStatePicker == 1)
        {
            enemyAnim.SetTrigger("AttackPlayer");
        }
    }

    public void AttackPlayer()
    {
        if (!_hasPlayerPosition)
        {
            _playerPosition = _player.position - transform.position;
            _playerPosition.Normalize();
            _hasPlayerPosition = true;
        }
        if (_hasPlayerPosition)
        {
            _enemyRigidbody2D.velocity = _playerPosition * _attackPlayerSpeed;
        }

        if (_isTouchingWall || _isTouchingDown)
        {
            _enemyRigidbody2D.velocity = Vector2.zero;
            _hasPlayerPosition = false;
            enemyAnim.SetTrigger("Slam");
        }
        
    }

    public void LaserToPlayer()
    {
        
    }

    private void FlipTowardsPlayer()
    {
        float playerDirection = _player.position.x - transform.position.x;

        if (playerDirection > 0 && _isFacingLeft)
        {
            Flip();
        }
        else if (playerDirection < 0 && !_isFacingLeft)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingLeft = !_isFacingLeft;
        _idelMoveDirection.x *= -1;
        _attackMoveDirection.x *= -1;
        transform.Rotate(0,180,0);
    }
}
