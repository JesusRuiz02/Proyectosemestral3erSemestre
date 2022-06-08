using UnityEngine;

public class MinibossDeath : MonoBehaviour
{
    private Enemy _enemy;
    [SerializeField] private GameObject _miniboss = default;
    [SerializeField] private GameObject _firstWall = default;
    [SerializeField] private GameObject _secondWall = default;
    [SerializeField] private bool _MinibossIsActive = false;
    private void Update()
    {
        if (_MinibossIsActive)
        {
            float health = _miniboss.GetComponent<Enemy>().Health;
            if (health <=0)
            {
                MinibossIsDisabled();
            }   
        }
    }

    public void MinibossIsEnabled()
    {
        _miniboss = GameObject.FindGameObjectWithTag("Miniboss");
        _MinibossIsActive = true;
    }

    private void MinibossIsDisabled()
    {
        _MinibossIsActive = false;
        _miniboss.GetComponent<Miniboss>().enabled = false;
        _miniboss.GetComponent<MinibossAnimation>().AnimationDeath();
        _firstWall.GetComponent<ActivateWall>().DisableObject();
        _secondWall.AddComponent<ActivateWall>().DisableObject();
    }
}
