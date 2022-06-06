using System;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Enemy _enemy = default;
    [SerializeField] private Rigidbody2D _rigidbody2D = default;
    [SerializeField] private float _knockBackForceX = 300;
    [SerializeField] private float _knockBackForceY = 200;
    [SerializeField] private GameObject _particle = default;
    [SerializeField] [CanBeNull] private GameObject _weapon = default;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Weapon"))
        {
            _enemy.ReduceHealth(collider.GetComponent<Spell>()._bulletdamage);
        }
        if (_enemy.Health <= 0)
        {
            _weapon.GetComponent<Weapon>().Recharge(GetComponent<Enemy>().BulletsAmount);
            Destroy(gameObject, 0.001f);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Melee"))
        {
            Vector2 knocbackForce = col.transform.position.x > transform.position.x ? new Vector2(-_knockBackForceX, _knockBackForceY)  : new Vector2(_knockBackForceX, _knockBackForceY);
            _enemy.ReduceHealth(col.gameObject.GetComponent<MeleeWeapon>().MeleeDamage);
            Instantiate(_particle, transform.position, Quaternion.identity);
            _rigidbody2D.AddForce(knocbackForce, ForceMode2D.Force);
            Debug.Log("golpeo");
        }

        if (_enemy.Health <= 0)
        {
            _weapon.GetComponent<Weapon>().Recharge(_enemy.BulletsAmount);
            Destroy(gameObject, 0.001f);
        }
    }
}