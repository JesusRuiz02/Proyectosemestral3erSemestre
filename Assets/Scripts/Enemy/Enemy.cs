using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _healthPoints = default;
    [SerializeField] private float _speed = default;
    [SerializeField] private float _damageToGive = default;
    [SerializeField] private float _boost = default;
    [SerializeField] private float _timeToDestroy = 0;

    public float Boost => _boost;
    public float DamageToGive => _damageToGive;
    public float Health => _healthPoints;
    public float Speed => _speed;
    public float TimeToDestroy => _timeToDestroy;
 

    public void ReduceHealth(float amount)
    {
        _healthPoints -= amount;
    }
}