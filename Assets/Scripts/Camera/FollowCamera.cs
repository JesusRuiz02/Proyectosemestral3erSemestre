using System;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    public Vector3 _offset;

    private void Start()
    {
        transform.position = new Vector3(52.2f, _player.position.y + _offset.y, _offset.z);
    }

    void Update()
    {
        transform.position = new Vector3( 52.2f, _player.position.y + _offset.y, _offset.z);
    }
}
