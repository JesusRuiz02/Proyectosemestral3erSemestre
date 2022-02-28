using System.Collections;
using UnityEngine;
public class Dash : MonoBehaviour
{
    [SerializeField] private float interval = .5f;
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
        var steps = (destino-PosActual / interval);
        for(int i = 0; i < numberofsteps; i++)
        {
            transform.position += Vector3.right * steps;
            yield return new WaitForSeconds(.02f);
        }
    }
}
