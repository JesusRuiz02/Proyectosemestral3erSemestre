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
            _enemy._healthPoints -= collider.GetComponent<Spell>()._bulletdamage;
        }

        if (_enemy._healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
