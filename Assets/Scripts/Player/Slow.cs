using System.Collections;
using System.Linq;
using UnityEngine;

public class Slow : MonoBehaviour
{
 
    void Update()
    {
        if (Input.GetKey(KeyCode.W) )
        {
            Time.timeScale = .2f;
        }
        else 
        {
            Time.timeScale = 1;
        }
    }
}
