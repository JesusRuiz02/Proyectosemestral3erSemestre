using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 10;
    [SerializeField] private float _currentHealth = default;
    [SerializeField] private bool _isInmune = false;
    [SerializeField] private float _inmunityTime = 1.5f;
    [SerializeField] private float _blinkingtime = 1.5f;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private float _knockbackForceX = 50;
    [SerializeField] private float _knockbackForceY = 10;
    private Rigidbody2D _rigidbody2D;
    
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _currentHealth = _maxHealth;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy") && !_isInmune)
        {
            _currentHealth -= collider.GetComponent<Enemy>().DamageToGive;
            StartCoroutine(Inmunity( 2, _blinkingtime));
            
            if (collider.transform.position.x > transform.position.x)
            {
                _rigidbody2D.AddForce(new Vector2(-_knockbackForceX,_knockbackForceY), ForceMode2D.Force);
            }
            else
            {
                _rigidbody2D.AddForce(new Vector2(_knockbackForceX,_knockbackForceY), ForceMode2D.Force);
            }
            
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Inmunity( int _numBlinks, float _seconds)
    {
        _isInmune = true;
        yield return new WaitForSeconds(_inmunityTime);
        for (int i = 0; i < _numBlinks * 2; i++)
        {
            _sprite.enabled = !_sprite.enabled;
            yield return new WaitForSeconds(_seconds);
        }
        _sprite.enabled = true;
        _isInmune = false;
    }
}
