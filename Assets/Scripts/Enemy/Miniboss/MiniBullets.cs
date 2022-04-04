using UnityEngine;

public class MiniBullets : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private float _speed = 20;
    void Start()
    {
        _rigidBody2D.AddForce(transform.right * _speed);
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collider.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
       
    }
}
