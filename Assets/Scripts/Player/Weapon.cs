using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _firepoint = default;
    [SerializeField] private GameObject _playerbullet = default;
    public float _bulletdamage = 5;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {   
            shoot();
        }
    }

    private void shoot()
    {
        Instantiate(_playerbullet, _firepoint.position, _firepoint.rotation);
    }
}

