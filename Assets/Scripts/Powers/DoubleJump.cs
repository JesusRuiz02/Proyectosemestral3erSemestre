using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private const string PLAYER = "Player";
    private Rigidbody2D _rigidbody2D = null;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == PLAYER)
        {
            Destroy(gameObject);
        }
   
    }
}
