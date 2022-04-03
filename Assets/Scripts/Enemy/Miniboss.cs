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
    [SerializeField] private Rigidbody2D _enemyRigidbody2D;
    [SerializeField] private GameObject _proyectile = default;
    [SerializeField] private float _timer = 0f;
    [SerializeField] private float _maxtimer = 15f;


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
        int randomStatePicker = Random.Range(0,4);
        if (randomStatePicker == 0)
        {
           LaserAttack();
            _maxtimer = 10f;
        }
        else if (randomStatePicker == 1)
        {
            LaserAttack();
            _maxtimer = 5f;
        }
        else if (randomStatePicker == 2)
        {
          LaserAttack();
            _maxtimer = 8f;
        }
        else if (randomStatePicker == 3)
        {
           LaserAttack();
            _maxtimer = 7f;
        }
    }

 
    private void LaserAttack()
    {
        if (_targetLocation == Vector3.zero)
            _targetLocation = transform.position;
        Vector3 originalLocation = transform.position;
        transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEase);
        transform.DOMove(originalLocation, _moveDuration).SetEase(_moveEase).SetDelay(2f);
        Instantiate(_proyectile, transform.position, quaternion.identity);
        _timer = 0;
    }
    
    private void AttackLeftRight()
    {
        if (_targetLocation == Vector3.zero)
        {
            _targetLocation = transform.position;
        }
        Vector3 originalLocation = transform.position;
        DOTween.Sequence()
            .Append(transform.DOMove(_targetLocation, 2f).SetEase(_moveEase))
            .Append(transform.DOMove(_targetsecondLocation, _moveDuration).SetEase(_moveEase).SetDelay(1.5f))
            .Append(transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEase))
            .Append(transform.DOMove(_targetsecondLocation, _moveDuration).SetEase(_moveEase))
            .Append(transform.DOMove(originalLocation, _moveDuration).SetEase(_moveEase));
        _timer = 0;
    }

    private void AttackToCorners()
    {
        if (_targetLocation == Vector3.zero)
        {
            _targetLocation = transform.position;
        }
        Vector3 originalLocation = transform.position;
        DOTween.Sequence()
            .Append(transform.DOPath(_pathvalue , 10f, PathType.Linear , PathMode.Sidescroller2D, 10, Color.blue));
        _timer = 0;
    }

    private void Rotate()
    {
        transform.DORotate(new Vector3(0, 0, 720), 6, RotateMode.FastBeyond360);
        _timer = 0;
    }

}
