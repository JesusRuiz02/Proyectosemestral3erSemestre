using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;
using Unity.Collections;

public class Miniboss : MonoBehaviour
{
    [SerializeField] private Vector3 _targetLocation = Vector3.zero;
    [SerializeField] private  Vector3 _targetsecondLocation = Vector3.zero;
    [Range(0.5f, 10f), SerializeField] private float _moveDuration = 0.5f;
    [SerializeField] private Ease _moveEase = Ease.Linear;

    [Header("Other")]
    [SerializeField] private Rigidbody2D _enemyRigidbody2D;
    private Animator enemyAnim;
    [SerializeField] private bool _isAttacking = false;


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
       enemyAnim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (_isAttacking == false)
        {
            RandomStatePicker();
        }
        minibossState();
    }

    private void RandomStatePicker()
    {
        _isAttacking = true;
        int RandomStatePicker = Random.Range(0,3);
        if (RandomStatePicker == 0)
        {
            _doTweenType = DoTweenType.AttackToCorners;
        }
        else if (RandomStatePicker == 1)
        {
            _doTweenType = DoTweenType.MovementOfLaser;
        }
        else if (RandomStatePicker == 2)
        {
            _doTweenType = DoTweenType.AttackLeftToRight;
        } 
    }

    private void minibossState()
    {
        if (_doTweenType == DoTweenType.MovementOfLaser)
        {
            if (_targetLocation == Vector3.zero)
                _targetLocation = transform.position;
            Vector3 originalLocation = transform.position;
            DOTween.Sequence()
                .Append(transform.DOMove(_targetLocation, _moveDuration).SetEase(_moveEase))
                .Append(transform.DOMove(originalLocation, _moveDuration).SetEase(_moveEase).SetDelay(2f));
            _isAttacking = false;
        }

        if (_doTweenType == DoTweenType.AttackLeftToRight)
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
            _isAttacking = false;
        }

        if (_doTweenType == DoTweenType.AttackToCorners)
        {
            if (_targetLocation == Vector3.zero)
            {
                _targetLocation = transform.position;
            }
            Vector3 originalLocation = transform.position;

            DOTween.Sequence()
                .Append(transform.DOPath(_pathvalue , 10f, PathType.CatmullRom , PathMode.Sidescroller2D, 10, Color.blue));
            _isAttacking = false;
        }
    }

}
