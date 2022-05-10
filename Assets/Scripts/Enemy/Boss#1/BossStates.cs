using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class BossStates : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D = default;
    [SerializeField] private float _randomState = default;
    [SerializeField] private float _power = 1200;
    [SerializeField] private bool _facingRight = true;
    [Header("GameObjects")]
    [SerializeField] private GameObject _whipCollider = default;
    [SerializeField] private GameObject _targetPlayer = default;
    [SerializeField] private GameObject _smashColliderRight = default;
    [SerializeField] private GameObject _smashColliderLeft = default;
    [SerializeField] private GameObject _particle = default;
    [SerializeField] private GameObject _spores = default;
    
    
    [Header("Vectors")]
    [SerializeField] private Vector3[] _pathvalue = new Vector3[3];
    [SerializeField] private Vector3 targetToAttack = Vector3.zero;
    [SerializeField] private Vector3 _targetLocation = Vector3.zero;
    [SerializeField] private Vector2 _middlescreen = Vector2.zero;
    [SerializeField] private Vector2 _smashpoint = Vector2.zero;
    [SerializeField] private Vector2 _targetCorner1 = default; 
    [SerializeField] private Vector2 _targetCorner2 = default;
    [SerializeField] private Transform[] firepoints;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        RandomStatePicker();
    }

    private void RandomStatePicker()
    {
        _randomState = Random.Range(0, 3);
        if (_randomState == 1)
        {
            StartCoroutine(ThrowingSpore());
        }
        else if (_randomState == 0)
        {
            Smash();
        }
        else if (_randomState == 2)
        {
            AttackPlayer();
        }
        
    }

    private IEnumerator WhipAttack()
    {
        yield return new WaitForSeconds(2f);
        _whipCollider.SetActive(true);
    }

    private void AttackPlayer()
    {
        _targetLocation = transform.position;
        var target = transform.position.x > _targetPlayer.transform.position.x ? _targetCorner1 : _targetCorner2;
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(target, 2f).SetEase(Ease.Linear));
        targetToAttack = _targetPlayer.transform.position;
        _pathvalue[0] = targetToAttack;
        _pathvalue[1] = target;
        _pathvalue[2] = _targetLocation;
        sequence.Append(transform.DOPath(_pathvalue, 5f, PathType.Linear, PathMode.Sidescroller2D ,10,Color.red).SetDelay(2f));
        sequence.AppendCallback(RandomStatePicker);
    }

    private void Smash()
    {
        _targetLocation = transform.position;
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(_middlescreen, 2f).SetEase(Ease.Flash));
        sequence.Append(transform.DOMove(_smashpoint, 0.1f).SetEase(Ease.Linear).SetDelay(1f));
        RepeatSmashInvoke();
        sequence.AppendCallback(RandomStatePicker);
    }

    private void CreateSmashCollider()
    {
        Instantiate(_smashColliderLeft, new Vector3(14.8f,1,0), Quaternion.identity);
        Instantiate(_smashColliderRight, new Vector3(14.2f, 1, 0) ,Quaternion.identity);
        Instantiate(_particle, new Vector3(14.5f, 1, 0), quaternion.identity);
    }

    private void RepeatSmashInvoke()
    {
        InvokeRepeating("CreateSmashCollider", 3.1f, 400f);
    }

    private IEnumerator ThrowingSpore()
    {
        _targetLocation = transform.position;
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(_smashpoint, 1f)).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 3; i++)
        {
            var newSpore = Instantiate(_spores,firepoints[i].position , firepoints[i].rotation);
            newSpore.GetComponent<Rigidbody2D>().AddForce(firepoints[i].right *  _power, ForceMode2D.Impulse);
        }
        RandomStatePicker();
    }

    private void FixedUpdate()
    {
        FlippingSprite();
    }

    private void FlippingSprite()
    {
        if (transform.position.x > _targetPlayer.transform.position.x && !_facingRight)
        {
           Flip(); 
        }
        else if (transform.position.x < _targetPlayer.transform.position.x && _facingRight)
        {
            Flip();
        }
    }
    
    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
