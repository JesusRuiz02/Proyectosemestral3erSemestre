using System.Collections;
using System.Linq;
using UnityEngine;

public class Slow : MonoBehaviour
{
    [SerializeField] private bool isSlow;
    [SerializeField] private int _slowCharges=2;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W) && !isSlow && _slowCharges>0)
        {
            StartCoroutine("SlowFunction");
        }
        else if (!isSlow)
        {
            Time.timeScale = 1;
        }
    }
    IEnumerator SlowFunction()
    {
        if (_slowCharges>0)
        {
            isSlow = true;
            Time.timeScale = .2f;
            yield return new WaitForSeconds(.5f);
            isSlow = false;
            _slowCharges--;
        }
    }
}
