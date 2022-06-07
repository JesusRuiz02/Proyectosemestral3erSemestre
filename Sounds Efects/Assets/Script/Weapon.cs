using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Bullet;
    public float firerate = 0.5f;
    [SerializeField] private float nextfire = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            fire();
        }
    }

    void fire()
    {
        Instantiate(Bullet, transform.position, Quaternion.identity);
    }
}
