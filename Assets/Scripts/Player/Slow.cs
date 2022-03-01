using UnityEngine;

public class Slow : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            Time.timeScale = 0.2f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
