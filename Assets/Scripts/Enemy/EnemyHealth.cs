using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
     Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Weapon"))
        {
            _enemy._healtpoints -= -3f;
        }

        if (_enemy._healtpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
