using System.Collections;
using UnityEngine;

public class Slow : MonoBehaviour

{
    [SerializeField] private int _slowcharge = 2;
    [SerializeField] private bool _flagslow;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _flagslow = true;
            if (_slowcharge > 0 && _flagslow)
            {
                StartCoroutine("SlowFunction");
            }
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    IEnumerator SlowFunction()
    {
        print("entre");
        _flagslow = false;
        _slowcharge--;
        Time.timeScale = .2f;
        yield return new WaitForSeconds(3);
    }
}
