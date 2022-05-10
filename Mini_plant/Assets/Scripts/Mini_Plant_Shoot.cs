using UnityEngine;

public class Mini_Plant_Shoot : MonoBehaviour
{
    public Transform Player_pos;

    public Transform Instance_point;
    public GameObject Bullet;
    [SerializeField] float time;

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
