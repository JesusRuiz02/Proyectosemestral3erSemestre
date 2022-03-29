using UnityEngine;
public class decaying_enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 30;
    [SerializeField] private float _reversespeed = 20;
    [SerializeField] private float _playerDistance = 5;
    [SerializeField] private float _visionRange = 7;
    [SerializeField] private float _reverseRange = 7;
    [SerializeField] private float _firingRange = 5;
    [SerializeField] private Transform _player = default;
    [SerializeField] private Rigidbody2D rb2D;

    private void Update()
    {
        _playerDistance = Vector2.Distance(_player.position, rb2D.position);
        if (_playerDistance < _visionRange && _playerDistance > _reverseRange && _playerDistance > _firingRange)
        {
            Vector2 _target = new Vector2(_player.position.x, _player.position.y);
            Vector2 _newPos = Vector2.MoveTowards(rb2D.position, _target, _speed * Time.deltaTime);
            rb2D.MovePosition(_newPos);
        }

        else if (_playerDistance < _visionRange && _playerDistance > _reverseRange && _playerDistance <= _firingRange)
        {
            Vector2 _target = new Vector2(_player.position.x, _player.position.y);
            Vector2 _newPos = Vector2.MoveTowards(rb2D.position, _target, 0 * Time.deltaTime);
            rb2D.MovePosition(_newPos);
        }
        else if (_playerDistance < _reverseRange)
        {
            Vector2 _target = new Vector2(_player.position.x, _player.position.y);
            Vector2 _newPos = Vector2.MoveTowards(rb2D.position, _target, _reversespeed * Time.deltaTime);
            rb2D.MovePosition(_newPos);
        }
    }
}
