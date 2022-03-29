using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    [SerializeField] float _speed2 = 7f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey("a"))
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
        }
    }
}
