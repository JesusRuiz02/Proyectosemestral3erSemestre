using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velX;
    public float velY;
    public float velZ;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
    }
}
