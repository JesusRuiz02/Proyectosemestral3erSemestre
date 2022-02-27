using System;
using UnityEngine;

public class RotationWheel : MonoBehaviour
{
    [SerializeField] private float _speed = 35;

    private void FixedUpdate()
    {
        Rotation();
    }

    void Rotation()
    {
       transform.Rotate(0, 0, -_speed * Time.deltaTime);
    }   
}
