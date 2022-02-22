using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private int _speed = 3;
    private Rigidbody2D _rigidbody2D = null;
    
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
    }

    void PlayerController( bool dirX, int speed)
    {
        if (dirX)
        {
            transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0); 
        }
        else
        {
            transform.position = transform.position +new Vector3(speed*Time.deltaTime, 0, 0); 
        }
    }
}
