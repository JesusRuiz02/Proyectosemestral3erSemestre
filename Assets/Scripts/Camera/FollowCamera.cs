using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _player = default;
    public Vector3 _offset = default;
    [SerializeField] private float _xPoint = 52.2f;
    [SerializeField] private float _zoomcamera = 4.6f;

    private void Start()
    {
        transform.position = new Vector3(_xPoint, _player.position.y + _offset.y, _offset.z);
        GetComponent<Camera>().orthographicSize = _zoomcamera;
    }

    void Update()
    {
        transform.position = new Vector3( _xPoint, _player.position.y + _offset.y, _offset.z);
    }
}

