using UnityEngine;

public class Floor : MonoBehaviour
{
   [SerializeField] private float _speed = 1.5f;
    private bool _dir = true;

    // Update is called once per frame
    void Update()
    {
        Move(_dir);
    }

    private void Move( bool directionMovement)
    {
        if (directionMovement)
        {
            transform.Translate(Vector2.right * Time.deltaTime * _speed);
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
        }

    }

    private void OnCollisionEnter2D(Collision2D colliders)
    {
        if (colliders.gameObject.transform.CompareTag("Floor"))
        {
            _dir = !_dir;
        };
    }
}
