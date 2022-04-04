using System;
using System.Collections;
using UnityEngine;

public class ActivateWall : MonoBehaviour
{
    [SerializeField] private bool _isMinibossDeath = false;
    [SerializeField] private GameObject _miniboss = default;
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
        }
    }

    private IEnumerator _activatingBoss()
    {
        yield return new WaitForSeconds(2f);
        _miniboss.SetActive(true);
    }
}
