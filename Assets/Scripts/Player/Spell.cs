using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 20;

    void Start()
    {
        _rigidbody2D.velocity = Vector2.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}

