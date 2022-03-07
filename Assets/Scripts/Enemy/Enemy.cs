using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string _enemyName = default;
    public float _healthPoints = default;
    public float _speed = default;
    public float _damageToGive = default;
}
