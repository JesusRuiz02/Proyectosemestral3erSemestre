using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField] private int _speed = 3;

    void Update()
    {
        BulletMotion(_speed);
    }

    private void BulletMotion(int bulletspeed)
    {
        transform.Translate(Vector3.left * bulletspeed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collider.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
       
    }
}
