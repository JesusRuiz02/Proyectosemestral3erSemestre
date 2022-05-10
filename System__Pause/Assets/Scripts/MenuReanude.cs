using UnityEngine;

public class MenuReanude : MonoBehaviour
{
    [SerializeField] private GameObject ButtonPause;
    [SerializeField] private GameObject ButtonReanude;
    [SerializeField] private GameObject menuPause;

    public void Reanude()
    {
        Time.timeScale = 1f;
        ButtonReanude.SetActive(true);
        menuPause.SetActive(false);
    }
}
