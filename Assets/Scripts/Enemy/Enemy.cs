using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _healthPoints = default;
    [SerializeField] private float _speed = default;
    [SerializeField] private float _damageToGive = default;
    [SerializeField] private float _boost = default;
    [SerializeField] private float _bulletsAmount = 3;

    public float Boost => _boost;
    public float DamageToGive => _damageToGive;
    public float Health => _healthPoints;
    public float Speed => _speed;
    public float BulletsAmount => _bulletsAmount;

    public void ReduceHealth(float amount)
    {
        _healthPoints -= amount;
    }
}