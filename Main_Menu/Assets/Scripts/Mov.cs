using UnityEngine;

public class Mov : MonoBehaviour
{
    [SerializeField] float velocity = 5f;
    [SerializeField] float velocity2 = 7f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            transform.position += Vector3.left * velocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            transform.position += Vector3.right * velocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
        {
            transform.position += Vector3.forward * velocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            transform.position += Vector3.back * velocity * Time.deltaTime;
        }
    }
}
