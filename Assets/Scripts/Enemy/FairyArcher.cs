using Unity.Mathematics;
using UnityEngine;

public class FairyArcher : MonoBehaviour
{
    [SerializeField] private GameObject _magicbullet;
    
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
        InvokeRepeating("SpawnBullet",0f,3f);
    }

}
