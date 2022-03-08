using UnityEngine;

public class Aim : MonoBehaviour
{
    Camera cam;
    
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector2 dir = Input.mousePosition - cam.WorldToScreenPoint(transform.position);
        float ang = Vector2.SignedAngle(Vector2.up, dir);
        transform.rotation = (Quaternion.AngleAxis(ang, Vector3.forward));
    }
}
