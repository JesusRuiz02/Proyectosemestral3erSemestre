using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios;
    [SerializeField] private AudioSource Audiocontroller;

    private void Awake()
    {
        Audiocontroller = GetComponent<AudioSource>();
    }

    public void Selecionado(int indice, float volumen)
    {
        Audiocontroller.PlayOneShot(audios[indice], volumen);
    }
}