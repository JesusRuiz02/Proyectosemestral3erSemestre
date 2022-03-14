using UnityEngine;

public class FairyRaycast : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _distance = 40;
    private LayerMask _playerMask = 1 << 6;
    [SerializeField] private bool _dirRight = default;
    [SerializeField] private Transform _cast = default;
    void Start()
    {
        _rigidbody2D.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _dirRight = GetComponent<EnemyMovement>().WalksRight;
    }

    void FixedUpdate()
    {
        if (_dirRight)
        {
          RangeVision(Vector2.right, _cast);  
        }
        else
        {
          RangeVision(Vector2.left, _cast);   
        }
    }

    private void RangeVision(Vector2 direction, Transform Cast)
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, direction, _distance, _playerMask);
        if (hit2D.collider == null)
        {
            GetComponent<EnemyMovement>().BackToSpeed();
        }
        else
        {
            GetComponent<EnemyMovement>().FastToSpeed();
        }
    }
}
