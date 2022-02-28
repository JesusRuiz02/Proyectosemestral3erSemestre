using System.Collections;
using UnityEngine;
public class Dash : MonoBehaviour
{
    [SerializeField] private float interval = .01f;
    [SerializeField] private int numberofsteps = 10;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine("Dashfunction");
        }
    }

    IEnumerator Dashfunction()
    {
        var PosActual = transform.position.x;
        var destino = PosActual + 1f;
        var step = (destino-PosActual) / numberofsteps;
        for(int i = 1; i <= numberofsteps; i++)
        {
            transform.position += Vector3.right * step;
            yield return new WaitForSeconds(interval);
        }
    }
}
