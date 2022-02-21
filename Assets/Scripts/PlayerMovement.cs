using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private int _speed = 3; 
    Rigidbody2D rb2d;
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
            transform.position = transform.position + new Vector3(-(_speed)*Time.deltaTime,0,0);
        }

        if (Input.GetKey(KeyCode.D))
        {
           transform.position = transform.position + new Vector3(_speed*Time.deltaTime,0,0);
        }

    }

    void ControllerPlayer()
    {
        
    }
}
