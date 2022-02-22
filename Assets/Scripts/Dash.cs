using System.Collections;
using UnityEngine;
public class Dash : MonoBehaviour
{
    [SerializeField] private float interval = .01f;
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Dashfunction");

        }
        
    }

    IEnumerator Dashfunction()
    {
        var PosActual = transform.position.x;
        var steps = ((PosActual + 3.0f) / interval);
        for(int i = 0; i <= steps; i++)
        {
            //transform.position = (PosActual + (steps * i), 0f, 0f);
        }

        yield return new WaitForSeconds(interval);
    }
}

