using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string _enemyName = default;
    public float _healtpoints = default;
    public float _speed = default;
    [SerializeField] private float _damageTogive = default;
}
