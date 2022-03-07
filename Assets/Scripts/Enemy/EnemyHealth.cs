using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
     Enemy _enemy = default;

     private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Weapon"))
        {
            _enemy.ReduceHealth(collider.GetComponent<Spell>()._bulletdamage);  
        }

        if (_enemy.Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
