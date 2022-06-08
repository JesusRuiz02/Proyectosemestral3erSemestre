using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private Color _wantedColor = default;
    [SerializeField] private Button _buttonToClick = default;
    [SerializeField] private Button _buttonToClick2 = default;
    public void ChangeScenes()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeColorButton()
    {
        ColorBlock cb = _buttonToClick.colors;
        cb.normalColor = _wantedColor;
        cb.highlightedColor = _wantedColor;
        cb.pressedColor = _wantedColor;
        _buttonToClick.colors = cb;
    }

    public void Change2ndColorButton()
    {
        ColorBlock cb = _buttonToClick2.colors;
        cb.normalColor = _wantedColor;
        cb.highlightedColor = _wantedColor;
        cb.pressedColor = _wantedColor;
        _buttonToClick2.colors = cb;  
    }
}
