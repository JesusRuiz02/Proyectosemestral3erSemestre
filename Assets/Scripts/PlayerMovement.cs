using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private int _speed = 3; 
    Rigidbody2D rb2d;
    [SerializeField] 
    private float _jumpforce = 5.0f;
    [SerializeField]
    private int jumps = 2;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ControllerPlayerLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            ControllerPlayerRight();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
             Jump_DoubleJump();
        }

    }

    void ControllerPlayerLeft()
    {
        transform.position = transform.position + new Vector3(-(_speed) * Time.deltaTime, 0, 0);
    }
    void ControllerPlayerRight()
    {
        transform.position = transform.position + new Vector3(_speed*Time.deltaTime,0,0);
    }

    void Jump_DoubleJump()
    {
        if (jumps > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, _jumpforce), ForceMode2D.Impulse);
            jumps--;
        }

        if (jumps == 0)
        {
            return;
        }

    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag =="Floor")
        {
            jumps = 2;
        }
    }
}
