using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios;
    [SerializeField] private AudioSource controlAudio;

    private void Awake()
    {
        controlAudio = GetComponent<AudioSource>();
    }

    public void Selecionado (int indice, float volumen)
    {
        controlAudio.PlayOneShot(audios[indice], volumen);
    }
}
