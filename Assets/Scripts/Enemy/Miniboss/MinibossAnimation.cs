
using UnityEngine;

public class MinibossAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator = default;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void AnimationDeath()
    {
       _animator.SetTrigger("Death"); 
    }
}
