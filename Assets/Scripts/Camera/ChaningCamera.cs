using UnityEngine;

public class ChaningCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector3 _positioncamera = new Vector3(17, -0.5f, -10);

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
         ChangingCamera(_positioncamera);   
        }
    }

    private void ChangingCamera(Vector3 position)
    {
        _camera.transform.position = position;
    }
}
