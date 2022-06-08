using System;
using System.Collections;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _firepoint = default;
    [SerializeField] private GameObject _playerbullet = default;
    [SerializeField] private Vector3 _mousePos  = default;
    [SerializeField] private Camera _mainCamera = default;
    [SerializeField] private float _bulletsAmount = 75;
    [SerializeField] private bool _shootflag = false;
    [SerializeField] private float _timer = 0;
    [SerializeField] private float _maxTimer = 3;
    public Text _scoreText = default;

    private void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        if (_bulletsAmount > 0)
        {
            AimAndShoot();
        }
        else
        {
            _shootflag = true;
        }
        if (_shootflag)
        {
           Recharge();
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

    private void Recharge()
    {
        _timer += Time.deltaTime;
        if (_timer >= _maxTimer)
        {
            _bulletsAmount = 10;
            _shootflag = false;
            _timer = 0;
        }
    }
}