using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _firepoint = default;
    [SerializeField] private GameObject _playerbullet = default;
    [SerializeField] private Vector3 _mousePos  = default;
    [SerializeField] private Camera _mainCamera = default;

    private void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        _mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = _mousePos - transform.position;
        float RotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
       transform.rotation = Quaternion.Euler(0,0,RotationZ);
        if (Input.GetMouseButtonDown(1))
        {
            shoot();
        }
    }

    private void shoot()
    {
        Instantiate(_playerbullet, _firepoint.position, _firepoint.rotation);
    }
}