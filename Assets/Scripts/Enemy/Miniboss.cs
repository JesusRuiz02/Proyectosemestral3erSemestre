using System;
using UnityEngine;

public class Miniboss : MonoBehaviour
{
    [Header("Idel")] 
    [SerializeField] private float _idelMoveSpeed = default;
    [SerializeField] private Vector2 _idelMoveDirection = default;
    
    [Header("AttackUpDown")]
    [SerializeField] private float _attackMoveSpeed = default;
    [SerializeField] private Vector2 _attackMoveDirection = default;

    [Header("AttackPlayer")] 
    [SerializeField] private float _attackPlayerSpeed = default;
    [SerializeField] private Transform _player = default;

    [Header("Other")] 
    [SerializeField] private Transform _groundCheckUp = default;
    [SerializeField] private Transform _groundCheckDown = default;
    [SerializeField] private Transform _groundCheckWall = default;
    [SerializeField] private float _groundCheckRadius = default;
    [SerializeField] private LayerMask _groundLayer = default;
    private bool IsTouchingDown = default;
    private bool IsTouchingUp = default;
    private bool IsTouchingWall = default;
    private Rigidbody2D _enemyRigidbody2D;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        IsTouchingUp = Physics2D.OverlapCircle(_groundCheckUp.position, _groundCheckRadius, _groundLayer);
        IsTouchingDown = Physics2D.OverlapCircle(_groundCheckDown.position, _groundCheckRadius, _groundLayer);
        IsTouchingWall = Physics2D.OverlapCircle(_groundCheckWall.position, _groundCheckRadius, _groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(_groundCheckUp.position,_groundCheckRadius);
        Gizmos.DrawWireSphere(_groundCheckDown.position,_groundCheckRadius);
        Gizmos.DrawWireSphere(_groundCheckWall.position,_groundCheckRadius);
    }
}
