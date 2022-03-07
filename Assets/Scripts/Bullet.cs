using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _velocityX;
    public float _velocityY = 0;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(_velocityX, _velocityY);
    }

    void Update()
    {
        
    }
}
