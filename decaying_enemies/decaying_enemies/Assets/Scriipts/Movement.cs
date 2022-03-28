using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocidad = 3f;
    public float velocidad2 = 7f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey("a"))
        {
            transform.position += Vector3.left * velocidad * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            transform.position += Vector3.right * velocidad * Time.deltaTime;
        }
    }
}
