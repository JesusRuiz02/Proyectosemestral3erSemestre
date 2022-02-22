using UnityEngine;
public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private int _speed = 3;
    private bool Direction = true;
    private Rigidbody2D Rb2d = null;
    [SerializeField] private float _jumpforce = 5.0f;
    [SerializeField] private int jumps = 2;
    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Direction = true;
            PlayerController(Direction, _speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Direction = false;
            PlayerController(Direction, _speed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump_DoubleJump();
        }
    }
    void PlayerController( bool dirX, int speed)
    {
        if (dirX)
        {
            transform.position = transform.position + new Vector3(-(speed)*Time.deltaTime,0,0); 
        }
        else
        {
            transform.position = transform.position +new Vector3(speed*Time.deltaTime,0,0); 
        }
    }
    void Jump_DoubleJump()
    {
        if (jumps > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, _jumpforce), ForceMode2D.Impulse);
            jumps--;
        }
        if (jumps == 0) return; 
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag =="Floor")
        {
            jumps = 2;
        }
    }
}

