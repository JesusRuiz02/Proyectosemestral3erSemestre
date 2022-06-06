using Unity.Mathematics;
using UnityEngine;

public class FairyArcher : MonoBehaviour
{
    [SerializeField] private GameObject _magicbullet = default;
    [SerializeField] private float _repeatrate = 3f;
    [SerializeField] private Transform _firePoint = default;

    void Start()
    {
        RepeatingSpawn();
    }

    private void SpawnBullet()
    {
        Instantiate(_magicbullet, _firePoint.position, transform.rotation);
    }

    private void RepeatingSpawn()
    {
        InvokeRepeating("SpawnBullet",0f,_repeatrate);
    }
}

