using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string _enemyName = default;
    [SerializeField] private float _healthPoints = default;
    [SerializeField] private float _speed = default;
    public float _damageToGive = default;
    

    public float Health => _healthPoints;
    public float Speed => _speed;
    
    
    public void ReduceHealth(float amount)
    {
        _healthPoints -= amount;
        if (_healthPoints>= 0)
        {
            
        }
    }
}
