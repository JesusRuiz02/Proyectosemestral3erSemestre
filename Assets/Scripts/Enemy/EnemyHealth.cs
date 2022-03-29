using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Enemy _enemy = default;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _knockBackForceX = 200;
    [SerializeField] private float _knockBackForceY = 100;

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

        if (collider.CompareTag("Melee"))
        {
            _enemy.ReduceHealth(collider.GetComponent<MeleeWeapon>().MeleeDamage);
            if (collider.transform.position.x > transform.position.x)
            {
                _rigidbody2D.AddForce(new Vector2(-_knockBackForceX,_knockBackForceY), ForceMode2D.Force);
            }
            else
            {
                _rigidbody2D.AddForce(new Vector2(_knockBackForceX,_knockBackForceY), ForceMode2D.Force);
            }
        }

        if (_enemy.Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}