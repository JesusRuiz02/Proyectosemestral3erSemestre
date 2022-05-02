using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;
using Unity.Mathematics;

public class Miniboss : MonoBehaviour
{
    [SerializeField] private Vector3 _targetLocation = Vector3.zero;
    [SerializeField] private  Vector3 _targetsecondLocation = Vector3.zero;
    [Range(0.5f, 10f), SerializeField] private float _moveDuration = 0.5f;
    [SerializeField] private Ease _moveEase = Ease.Linear;

    [Header("Other")]
    [SerializeField] private Rigidbody2D _enemyRigidbody2D = default;
    [SerializeField] private GameObject _projectile = default;
    [SerializeField] private float _timer = 0f;
    [SerializeField] private float _maxtimer = 13f;
    [SerializeField] private Transform _firepoint = default;
    [SerializeField] private Transform _firepoint2 = default;
    [SerializeField] private Transform _firepoint3 = default;
    [SerializeField] private Transform _firepoint4 = default;
    [SerializeField] private GameObject _bullets = default;
    [SerializeField] private int _randomStatePicker = 5;
    [SerializeField] private DoTweenType _doTweenType = DoTweenType.MovementOfLaser;
    [SerializeField] private Vector3[] _pathvalue = new Vector3[3];
    private enum DoTweenType
    {
        MovementOfLaser,
        AttackLeftToRight,
        AttackToCorners,
        None
    }
    
    void Start()
    { 
       _enemyRigidbody2D.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _maxtimer)
        {
           RandomStatePicker();
        }
    }

    private void RandomStatePicker()
    {
         _randomStatePicker = Random.Range(0,4);
        if (_randomStatePicker == 0)
        {
            AttackToCorners();
            _maxtimer = 7f;
        }
        else if (_randomStatePicker == 1)
        {
            LaserAttack();
            _maxtimer = 5f;
        }
        else if (_randomStatePicker == 2)
        { 
            AttackLeftRight();
            _maxtimer = 7f;
        }
        else if (_randomStatePicker == 3)
        {
            Rotate();
            _maxtimer = 6f;
        }
    }

    private void LaserAttack()
    {
        CancelInvoke("CreateProjectiles");
        if (_targetLocation == Vector3.zero)
            _targetLocation = transform.position;
        Vector3 originalLocation = transform.position;
        transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEase);
        transform.DOMove(originalLocation, _moveDuration).SetEase(_moveEase).SetDelay(2f);
        RepeatLaserAttack();
        _timer = 0;
    }
    
    private void AttackLeftRight()
    {
        CancelInvoke("CreateLaserAttack");
        CancelInvoke("CreateProjectiles");
        if (_targetLocation == Vector3.zero)
        {
            _targetLocation = transform.position;
        }
        Vector3 originalLocation = transform.position;
        DOTween.Sequence()
            .Append(transform.DOMove(_targetLocation, 2f).SetEase(_moveEase))
            .Append(transform.DOMove(_targetsecondLocation, _moveDuration).SetEase(_moveEase).SetDelay(1f))
            .Append(transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEase))
            .Append(transform.DOMove(originalLocation, _moveDuration).SetEase(_moveEase));
        _timer = 0;
    }

    private void AttackToCorners()
    {
        CancelInvoke("CreateLaserAttack");
        CancelInvoke("CreateProjectiles");
        if (_targetLocation == Vector3.zero)
        {
            _targetLocation = transform.position;
        }
        Vector3 originalLocation = transform.position;
        DOTween.Sequence()
            .Append(transform.DOPath(_pathvalue , 7f, PathType.Linear , PathMode.Sidescroller2D, 10, Color.blue));
        _timer = 0;
    }

    private void Rotate()
    {
        CancelInvoke("CreateLaserAttack");
        transform.DORotate(new Vector3(0, 0, 720), 5, RotateMode.FastBeyond360);
        RepeatProjectiles();
        _timer = 0;
    }

    private void RepeatProjectiles()
    {
        InvokeRepeating("CreateProjectiles",0,1.5f);
    }
    
    private void CreateProjectiles()
    {
        Instantiate(_bullets, _firepoint.position, _firepoint.rotation);
        Instantiate(_bullets, _firepoint2.position, _firepoint2.rotation);
        Instantiate(_bullets, _firepoint3.position, _firepoint3.rotation);
        Instantiate(_bullets, _firepoint4.position, _firepoint4.rotation);
    }
    
    private void CreateLaserAttack()
    {
        Instantiate(_projectile, _firepoint.position, quaternion.identity); 
    }

    private void RepeatLaserAttack()
    {
        InvokeRepeating("CreateLaserAttack",1.8f, 400);
    }
}

