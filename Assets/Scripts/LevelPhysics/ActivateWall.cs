using System;
using UnityEngine;

public class ActivateWall : MonoBehaviour
{
    [SerializeField] private bool _isMinibossDeath = false;
    void Update()
    {
        if (_isMinibossDeath)
            this.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("Miniboss").SetActive(true);
        }
        
    }
}
