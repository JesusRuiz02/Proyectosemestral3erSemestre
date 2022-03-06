using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject cat;

    public float fireRate = 0.5f;
    float nextFire = 0.0f;
    
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }
    }

    void fire()
    {
        Instantiate(cat, transform.position, Quaternion.identity);
    }
}
