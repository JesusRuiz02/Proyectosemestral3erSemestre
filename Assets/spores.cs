
using UnityEngine;

public class spores : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
