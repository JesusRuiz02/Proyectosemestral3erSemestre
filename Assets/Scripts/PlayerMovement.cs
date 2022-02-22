using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private const string FLOOR = "Floor";
    
    [SerializeField] private int _speed = 3;
    private Rigidbody2D _rigidbody2D = null;
    [SerializeField] private float _jumpforce = 5.0f;
    [SerializeField] private int _jumps = 2;
    [SerializeField] private int _basejumps = 2;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            PlayerController(true, _speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerController(false, _speed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoubleJump();
        }
    }
    
    private void PlayerController( bool _moveRight, int speed)
    {
        if (_moveRight)
        {
            transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0); 
        }
        else
        { 
             transform.position = transform.position +new Vector3(speed * Time.deltaTime, 0, 0); 
        }
        
    }
    
   private void DoubleJump()
   
    {
        if (_jumps > 0)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpforce, ForceMode2D.Impulse);
            _jumps--;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == FLOOR)
        {
            _jumps = _basejumps;
        }
    }
}

