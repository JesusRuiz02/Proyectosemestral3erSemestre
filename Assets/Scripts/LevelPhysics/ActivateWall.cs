using System.Collections;
using UnityEngine;

public class ActivateWall : MonoBehaviour
{
    [SerializeField] private GameObject _boss = default;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(ActivatingBoss());
        }
    }

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator ActivatingBoss()
    {
        yield return new WaitForSeconds(2f);
        _boss.SetActive(true);
    }
    
}
