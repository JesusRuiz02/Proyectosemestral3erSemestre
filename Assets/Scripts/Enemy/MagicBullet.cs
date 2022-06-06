using System;
using UnityEngine;

public class MagicBullet : MonoBehaviour
{
    [SerializeField] private int _speed = 3;

    void Update()
    {
        BulletMotion(_speed);
    }

    private void BulletMotion(int bulletspeed)
    {
        transform.Translate(transform.right * bulletspeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}

