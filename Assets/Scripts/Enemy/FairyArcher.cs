using Unity.Mathematics;
using UnityEngine;

public class FairyArcher : MonoBehaviour
{
    [SerializeField] private GameObject _magicbullet = default;
    [SerializeField] private float _repeatrate = 3f;
    
    void Start()
    {
        RepeatingSpawn();
    }

    private void SpawnBullet()
    {
        Instantiate(_magicbullet, transform.position, quaternion.identity);
    }

    private void RepeatingSpawn()
    {
        InvokeRepeating("SpawnBullet",0f,_repeatrate);
    }

}

