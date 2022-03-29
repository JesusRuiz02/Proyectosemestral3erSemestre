using System.Collections;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] private float _meleeDamage = 10;
    [SerializeField] private bool _isActive = false;
    [SerializeField] private float _recoveryTime = 1;

    public float MeleeDamage => _meleeDamage;

    private void Update()
    {
        ActivateTheSwordCollider();
        if (Input.GetButtonDown("Fire1") && !_isActive)
        {
            StartCoroutine(ActivateTheSwordCollider());
        }
    }

    private IEnumerator ActivateTheSwordCollider()
    {
        GetComponent<CircleCollider2D>().enabled = true;
        _isActive = true;
        yield return new WaitForSeconds(_recoveryTime);
        _isActive = false;
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
