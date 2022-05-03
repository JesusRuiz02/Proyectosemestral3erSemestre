using UnityEngine;

public class Particles : MonoBehaviour
{
  [SerializeField] private GameObject _particlesmash = default;
    void Start()
    {
        RepeatParticlesInvoke();
    }

    private void CreateParticles()
    {
        Instantiate(_particlesmash, transform.position, Quaternion.identity);
    }

    private void RepeatParticlesInvoke()
    {
        InvokeRepeating("CreateParticles", 0f,0.4f);
    }
}
