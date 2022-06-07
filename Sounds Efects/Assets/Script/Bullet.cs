using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velx;
    float velY = 0;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(velx, velY);
    }
}
