using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;
using Unity.Mathematics;

public class Miniboss : MonoBehaviour
{
    [SerializeField] private GameObject _MinibossRoom = default;
    [SerializeField] private Vector3 _targetLocation = Vector3.zero;
    [SerializeField] private  Vector3 _targetsecondLocation = Vector3.zero;
    [Range(0.5f, 10f), SerializeField] private float _moveDuration = 0.5f;
    [SerializeField] private Ease _moveEase = Ease.Linear;
    [SerializeField] private int _randomStatePicker = 5;
    [SerializeField] private DoTweenType _doTweenType = DoTweenType.MovementOfLaser;
    [Header("Other")]
    [SerializeField] private Rigidbody2D _enemyRigidbody2D = default;
    [SerializeField] private GameObject _projectile = default;
    [SerializeField] private float _timer = 0f;
    [SerializeField] private float _maxtimer = 13f;
    
    [Header("RotateAttack")]
    [SerializeField] private Transform _firepoint = default;
    [SerializeField] private Transform _firepoint2 = default;
    [SerializeField] private Transform _firepoint3 = default;
    [SerializeField] private Transform _firepoint4 = default;
    [SerializeField] private GameObject _bullets = default;
    
    
    [Header("AttackToCorners")]
    [SerializeField] private Vector3[] _pathvalue = new Vector3[3];
    [SerializeField] private Vector3[] _pathvalueRotation = new Vector3[3];
    [SerializeField] private float _pathLimit = 5;
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
       _MinibossRoom = GameObject.FindGameObjectWithTag("MiniBoss");
       _MinibossRoom.GetComponent<MinibossDeath>().MinibossIsEnabled();
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
        CancelTheInvokes();
        _randomStatePicker = Random.Range(0,4);
         if (_randomStatePicker == 0)
        {
           LaserAttack();
            _maxtimer = 4.52f;
        }
        else if (_randomStatePicker == 1)
        {
            Rotate();
            _maxtimer = 6.5f;
        }
        else if (_randomStatePicker == 2)
        { 
            AttackLeftRight();
            _maxtimer = 5.55f;
        }
        else if (_randomStatePicker == 3)
        {
            AttackToCorners();
            _maxtimer = 5.05f;
        }
    }

    private void LaserAttack()
    {
        if (_targetLocation == Vector3.zero)
            _targetLocation = transform.position;
        Vector3 originalLocation = transform.position;
        transform.DORotate(new Vector3(0, 180, 30), 0.01f);
        transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEase);
        transform.DORotate(new Vector3(0, 0, 0), 0.01f).SetDelay(1);
        transform.DOMove(originalLocation, _moveDuration).SetEase(_moveEase).SetDelay(2f);
        RepeatLaserAttack();
        _timer = 0;
    }
    
    private void AttackLeftRight()
    {
        if (_targetLocation == Vector3.zero)
        {
            _targetLocation = transform.position;
        }
        Vector3 originalLocation = transform.position;
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DORotate(new Vector3(0, 180, 30), 0.01f));
        sequence.Append(transform.DOMove(_targetLocation, 1f).SetEase(_moveEase));
        sequence.Append(transform.DORotate(new Vector3(0, 0, 0), 0.01f));
        sequence.Append(transform.DOMove(_targetsecondLocation, _moveDuration).SetEase(_moveEase).SetDelay(1f));
        sequence.Append(transform.DORotate(new Vector3(0, 180, 0), 0.01f));
        sequence.Append(transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEase));
        sequence.Append(transform.DORotate(new Vector3(0, 0, 320), 0.01f));
        sequence.Append(transform.DOMove(originalLocation, _moveDuration).SetEase(_moveEase));
        _timer = 0;
    }

    private void AttackToCorners()
    {
        if (_targetLocation == Vector3.zero)
        {
            _targetLocation = transform.position;
        }
        Vector3 originalLocation = transform.position;
        var sequence = DOTween.Sequence();
        for (int i = 0; i < _pathLimit; i++)
        {
            sequence.Append(transform.DORotate(_pathvalueRotation[i], 0.01f));
            sequence.Append(transform.DOMove(_pathvalue[i], 1f).SetEase(_moveEase));
        }
        sequence.Append(transform.DORotate(new Vector3(0,0,0), 0.01f));
        _timer = 0;
    }

    private void Rotate()
    {
        transform.DORotate(new Vector3(0, 0, 0), 0.01f);
        RepeatProjectiles();
        transform.DORotate(new Vector3(0, 0, 720), 6,RotateMode.FastBeyond360);
        _timer = 0;
    }

    private void CancelTheInvokes()
    {
        transform.DORotate(new Vector3(0, 0, 0), 0.01f);
        CancelInvoke("CreateLaserAttack");
        CancelInvoke("CreateProjectiles");
    }

    private void RepeatProjectiles()
    {
        InvokeRepeating("CreateProjectiles",0,1f);
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

