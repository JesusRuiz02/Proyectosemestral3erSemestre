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
    [SerializeField] private Animator _animator = default;
    
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
       _animator = GetComponent<Animator>();
       RandomStatePicker();
    }
    
    private void RandomStatePicker()
    {
        CancelTheInvokes();
        _randomStatePicker = Random.Range(0,4);
         if (_randomStatePicker == 0)
        {
           LaserAttack();
        }
        else if (_randomStatePicker == 1)
        {
            AttackLeftRight();
        }
        else if (_randomStatePicker == 2)
        { 
           AttackToCorners();
        }
        else if (_randomStatePicker == 3)
        {
            Rotate();
        }
    }

    private void LaserAttack()
    {
        var sequence = DOTween.Sequence();
        if (_targetLocation == Vector3.zero)
            _targetLocation = transform.position;
        Vector3 originalLocation = transform.position;
        sequence.Append(transform.DORotate(new Vector3(0, 180, 30), 0.01f)).SetDelay(0.3f);
        sequence.Append(transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEase));
        sequence.Append(transform.DORotate(new Vector3(0, 0, 0), 0.01f).SetDelay(0.2f));
        sequence.Append(transform.DOMove(originalLocation, _moveDuration).SetEase(_moveEase).SetDelay(1f));
        RepeatLaserAttack();
        sequence.AppendCallback(RandomStatePicker);
    }
    
    private void AttackLeftRight()
    {
        if (_targetLocation == Vector3.zero)
        {
            _targetLocation = transform.position;
        }
        Vector3 originalLocation = transform.position;
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DORotate(new Vector3(0, 180, 30), 0.01f)).SetDelay(0.03f);
        sequence.Append(transform.DOMove(_targetLocation, 1f).SetEase(_moveEase));
        sequence.Append(transform.DORotate(new Vector3(0, 0, 0), 0.01f));
        sequence.Append(transform.DOMove(_targetsecondLocation, _moveDuration).SetEase(_moveEase).SetDelay(1f));
        sequence.Append(transform.DORotate(new Vector3(0, 180, 0), 0.01f));
        sequence.Append(transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEase));
        sequence.Append(transform.DORotate(new Vector3(0, 0, 320), 0.01f));
        sequence.Append(transform.DOMove(originalLocation, _moveDuration).SetEase(_moveEase));
        sequence.AppendCallback(RandomStatePicker);
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
        sequence.AppendCallback(RandomStatePicker);
    }

    private void Rotate()
    {
        var sequence = DOTween.Sequence();
        _animator.SetTrigger("Rotation");
        sequence.Append(transform.DORotate(new Vector3(0, 0, 0), 0.01f)).SetDelay(0.5f);
        RepeatProjectiles();
        sequence.Append(transform.DORotate(new Vector3(0, 0, 720), 6, RotateMode.FastBeyond360));
        sequence.AppendCallback(RandomStatePicker);

    }

    private void CancelTheInvokes()
    {
        transform.DORotate(new Vector3(0, 0, 0), 0.01f);
        CancelInvoke("CreateLaserAttack");
        CancelInvoke("CreateProjectiles");
    }

    private void RepeatProjectiles()
    {
        InvokeRepeating("CreateProjectiles",0.5f,1f);
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
        InvokeRepeating("CreateLaserAttack",1.7f, 400);
    }
    
}

