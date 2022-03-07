using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Cat;
    
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float nextfire = 0.0f;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextfire)
        {
            nextfire = Time.time + fireRate;
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(Cat, transform.position, Quaternion.identity);
    }

}
