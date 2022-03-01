using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private float _interval = .01f;
    [SerializeField] private int _numberofsteps = 10;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine("Dashfunction");
        }
    }

    IEnumerator Dashfunction()
    {
        var _currentPosition = transform.position.x;
        var _destiny = _currentPosition + 3f;
        var _step = (_destiny-_currentPosition) / _numberofsteps;
        for(int i = 1; i <= _numberofsteps; i++)
        {
            transform.position += Vector3.right * _step;
            yield return new WaitForSeconds(_interval);
        }
    }
}
