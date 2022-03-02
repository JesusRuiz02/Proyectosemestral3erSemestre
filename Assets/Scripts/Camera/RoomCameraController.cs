using UnityEngine;

public class RoomCameraController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector3 _positioncamera = new Vector3(17, -0.5f, -10);

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
         ChangeCameraPosition(_positioncamera);   
        }
    }

    private void ChangeCameraPosition(Vector3 position)
    {
        _camera.transform.position = position;
    }
}
