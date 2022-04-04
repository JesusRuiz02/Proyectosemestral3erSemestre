using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private float _speed = 20;
    public float _bulletdamage = 5;
    void Start()
    {
        _rigidBody2D.AddForce(transform.right * _speed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy") || collider.CompareTag("Floor") || collider.CompareTag("Miniboss"))  
        {
            Destroy(gameObject);
        }
    }
}
