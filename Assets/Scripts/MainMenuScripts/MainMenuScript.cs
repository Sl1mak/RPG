using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject settings, mainButtons, loadPanelAsGameObject;
    public Image loadPanel;

    private void Start()
    {
        Color blackTransparentColor = loadPanel.color;
        blackTransparentColor.a = 0;
        loadPanel.color = blackTransparentColor;

        loadPanelAsGameObject.SetActive(false);
        settings.SetActive(false);
    }

    public void GameStartButton()
    {
        loadPanelAsGameObject.SetActive(true);
        loadPanel.DOFade(1, 2).OnComplete(() => { SceneManager.LoadScene("GameMenu"); });
    }

    public void SettingsButton()
    {
        settings.SetActive(true);
        mainButtons.SetActive(false);
    }

    public void CloseSettingsButton()
    {
        settings.SetActive(false);
        mainButtons.SetActive(true);
    }
}
