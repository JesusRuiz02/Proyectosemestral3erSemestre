using System;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private int _speed = 3;
    private bool Direction = true;
    private Rigidbody2D Rb2d = null;
    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
      if (Input.GetKey(KeyCode.A))
      {
        Direction = true;
        PlayerController(Direction, _speed);
      }
      if (Input.GetKey(KeyCode.D))
      {
        Direction = false;
        PlayerController(Direction, _speed);
      }
    }
    void PlayerController( bool dirX, int speed)
    {
        if (dirX)
        {
            transform.position = transform.position + new Vector3(-(speed)*Time.deltaTime,0,0); 
        }
        else
        {
            transform.position = transform.position +new Vector3(_speed*Time.deltaTime,0,0); 
        }
    }
}
