using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform Player_pos;

    public Transform Instance_point;
    public GameObject Bullet;
    private float time;

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
