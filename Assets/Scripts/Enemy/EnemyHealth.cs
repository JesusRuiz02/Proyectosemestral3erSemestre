using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
     Enemy _enemy = default;
     [SerializeField] private float _damage = default;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _damage = GetComponent<Weapon>()._bulletdamage;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Weapon"))
        {
            _enemy._healthPoints  -= _damage;
        }

        if (_enemy._healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
