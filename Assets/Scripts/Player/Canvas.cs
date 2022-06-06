using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    public bool Istrue = false;
    public GameObject tutorialScreen;
    private void FixedUpdate()
    {
        if (Istrue)
     {
         tutorialScreen.SetActive(true);
     }
      else
      {
        tutorialScreen.SetActive(false); 
      }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    Istrue = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
    Istrue = false;
    }
}