using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;

    private const string FLOORTAG = "Floor";

    private bool _dir = true;

    void Update()
    {
        Move(_dir);
    }

    private void Move(bool directionMovement)
    {
        transform.Translate((directionMovement ? Vector3.right : Vector3.left) * (Time.deltaTime * _speed));
    }

    private void OnCollisionEnter2D(Collision2D colliders)
    {
        if (colliders.gameObject.tag == FLOORTAG)
        {
            _dir = !_dir;
        }

        ;
    }
}