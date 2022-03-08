using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _healthPoints = default;
    [SerializeField] private float _speed = default;
    [SerializeField] private float _damageToGive = default;

    public float DamageToGive => _damageToGive;
    public float Health => _healthPoints;
    public float Speed => _speed;

    public void ReduceHealth(float amount)
    {
        _healthPoints -= amount;
    }
}