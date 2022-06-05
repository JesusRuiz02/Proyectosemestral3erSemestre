using UnityEngine;

public class Enable_Camera : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindWithTag("MainCamera").GetComponent<FollowCamera>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindWithTag("MainCamera").GetComponent<FollowCamera>().enabled = false;
        }
    }
}

