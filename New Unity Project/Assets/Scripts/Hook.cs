using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private Camera mainCamera = default;
    [SerializeField] private LineRenderer _lineRenderer = default;
    [SerializeField] private DistanceJoint2D _distanceJoint = default;
    
    void Start()
    {
        _distanceJoint.enabled = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _lineRenderer.SetPosition(0, mousePos);
            _lineRenderer.SetPosition(1, transform.position);
            _distanceJoint.connectedAnchor = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
        }

        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
        }

        if (_distanceJoint.enabled)
        {
            _lineRenderer.SetPosition(1, transform.position);
        }
    }
}
