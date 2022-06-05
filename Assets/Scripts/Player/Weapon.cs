using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _firepoint = default;
    [SerializeField] private GameObject _playerbullet = default;
    [SerializeField] private Vector3 _mousePos  = default;
    [SerializeField] private Camera _mainCamera = default;
    [SerializeField] private float _bulletsAmount = 75;
    public Text _scoreText = default;

    private void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        if (_bulletsAmount >= 0)
        {
            AimAndShoot();
        }

        _scoreText.text = _bulletsAmount.ToString("0");

    }
    private void shoot()
    {
        Instantiate(_playerbullet, _firepoint.position, _firepoint.rotation);
        _bulletsAmount--;
    }

    private void AimAndShoot()
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

    public void Recharge(float amountOfBullets)
    {
        _bulletsAmount += amountOfBullets;
    }
}