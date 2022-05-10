using System;
using UnityEngine;

public class SmashCollider : MonoBehaviour
{

    [SerializeField] private bool _direction = default;
    [SerializeField] private Rigidbody2D _rigidbody2D = default;
    [SerializeField] private float _power = 1200;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        var target = _direction ? Vector2.right : Vector2.left;
        _rigidbody2D.AddForce(target * _power, ForceMode2D.Force);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
