using UnityEngine;

public class Mini_Plant_Shoot : MonoBehaviour
{
    [SerializeField] public Transform Player_pos;
    [SerializeField] public Transform Instance_point;
    [SerializeField] public GameObject Bullet;
    [SerializeField] private float time;

    void Update()
    {
        time += Time.deltaTime;
        if (time>=2)
        {
            Instantiate(Bullet, Instance_point.position, Quaternion.identity);
            time = 0;
        }
    }
}
