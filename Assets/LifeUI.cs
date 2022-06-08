using System;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    [SerializeField] private Sprite _complete, three_quarters, _half, one_quarter, empty;
    [SerializeField] private GameObject _player = default;
    [SerializeField] private float _health = 100;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    public void UpdatingLife()
     {
          _health = _player.GetComponent<PlayerHealth>().Health;
          ChangingSprite();
     }
    private void ChangingSprite()
    {
        if (_health>75)
        {
           GetComponent<UnityEngine.UI.Image>().sprite = _complete;
        }
        else if(_health>50)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = three_quarters;
        }
        else if(_health>25)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = _half;
        }
        else if(_health>0)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = one_quarter;
        }
        else if (_health<=0)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = empty;
        }
    }
}
