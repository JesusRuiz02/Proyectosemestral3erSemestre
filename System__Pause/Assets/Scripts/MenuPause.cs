using UnityEngine;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject ButtonPause;
    [SerializeField] private GameObject ButtonReanude;
    [SerializeField] private GameObject menuPause;

    public void Pause()
    {
        Time.timeScale = 0f;
        ButtonPause.SetActive(true);
        menuPause.SetActive(true);
    }
}
