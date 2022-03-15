using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string FLOOR_TAG = "Floor";
    private const string MOVING_FLOOR_TAG = "MovingFloor";
    private bool _facingRight = true;
    private float _velocityX = default;
    [SerializeField] private float _speed = 3;
    private float _velocityY = default;
    [SerializeField] private float _jumpHeight = default;
    private Rigidbody2D _rigidbody2D = null;
    [SerializeField] private int _jumps = 2;
    [SerializeField] private int _basejumps = 2;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
    }

    private void Movement()
    {
        _velocityX = Input.GetAxis("Horizontal");
        _velocityY = _rigidbody2D.velocity.y;
        _rigidbody2D.velocity = new Vector2(_velocityX * _speed, _velocityY);
        if (_velocityX!=0) animator.SetBool("Run", true);
        else animator.SetBool("Run",false);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
