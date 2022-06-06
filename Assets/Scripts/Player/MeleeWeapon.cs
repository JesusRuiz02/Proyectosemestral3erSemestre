using System;
using System.Collections;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] private float _meleeDamage = 10;
    [SerializeField] private bool _isActive = false;
    [SerializeField] private float _recoveryTime = 1;
    [SerializeField] private GameObject _player = default;

    public float MeleeDamage => _meleeDamage;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        ActivateTheSwordCollider();
        if (Input.GetButtonDown("Fire1") && !_isActive)
        {
            _player.GetComponent<Animator>().SetTrigger("TriggerPunch");
            StartCoroutine(ActivateTheSwordCollider());
        }
    }

    private IEnumerator ActivateTheSwordCollider()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        _isActive = true;
        yield return new WaitForSeconds(_recoveryTime);
        _isActive = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}

