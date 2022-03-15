using UnityEngine;

public class MagicBullet : MonoBehaviour
{
    [SerializeField] private int _speed = 3;
    [SerializeField] private float _limitdistance = 13f;
    
    void Update()
    {
        BulletMotion(_speed);
        EndOfTheBullet(_limitdistance);
    }

    private void BulletMotion(int bulletspeed)
    {
        transform.Translate(Vector3.right * bulletspeed * Time.deltaTime);
    }

    private void EndOfTheBullet( float limit)
    {
        if (transform.position.x >= limit)
        {
           Destroy(gameObject); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

