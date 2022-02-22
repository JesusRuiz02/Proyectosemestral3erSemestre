using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private int _speed = 3;
    private Rigidbody2D _rigidbody2D = null;
    [SerializeField] private float _jumpforce = 5.0f;
    [SerializeField] private int _jumps = 2;
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
            Jump_DoubleJump();
        }
    }
    
    private void PlayerController( bool dirX, int speed)
    {
        if (dirX)
        {
            transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0); 
        }
        else
        {
            transform.position = transform.position +new Vector3(speed * Time.deltaTime, 0, 0); 
        }
    }
    
   private void Jump_DoubleJump()
    {
        if (_jumps > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, _jumpforce), ForceMode2D.Impulse);
            _jumps--;
        }
        if (_jumps == 0) return; 
    }
    
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Floor")
        {
            _jumps = 2;
        }
    }
}

