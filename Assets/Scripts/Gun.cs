using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Cat;

    public float fireRate = 0.5f;
    float nextfire = 0.0f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextfire)
        {
            nextfire = Time.time + fireRate;
            fire();
        }
    }

    void fire()
    {
        Instantiate(Cat, transform.position, Quaternion.identity);
    }


}
