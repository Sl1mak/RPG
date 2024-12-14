using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LocationButtonScript : MonoBehaviour
{
    public string mainName, sceneNameIfEmpty, nameToLoadFromSave;
    public float scaleUp = 1.2f, scaleDuration = 0.2f;

    private bool isSelect;
    private string sceneToLoad;

    private Vector3 startScale;

    public Camera mainCamera;
    public Text nameText, yesButtonText, noButtonText;
    public Button yesButton, noButton;
    public GameObject locationTexts, loadPanelAsGameObject;
    public Image loadPanel;

    private void Start()
    {
        startScale = transform.localScale;
        nameText.text = mainName;
        isSelect = false;

        Color whiteTransparentColor = nameText.color;
        whiteTransparentColor.a = 0;
        nameText.color = whiteTransparentColor;
        yesButtonText.color = whiteTransparentColor;
        noButtonText.color = whiteTransparentColor;

        locationTexts.SetActive(false);
        loadPanel.DOFade(0, 2)/*.OnComplete(() => { loadPanelAsGameObject.SetActive(false); })*/;

        sceneToLoad = PlayerPrefs.GetString(nameToLoadFromSave);
        if (sceneToLoad == string.Empty) { sceneToLoad = sceneNameIfEmpty; }
    }

    public void OnPointerEnter()
    {
        if (!isSelect) { transform.DOScale(startScale * scaleUp, scaleDuration); }

    }

    public void OnPointerExit()
    {
        transform.DOScale(startScale, scaleDuration);
    }

    public void OnPointerClick()
    {
        GameMenuScript.isFollowing = false;
        isSelect = true;
        transform.DOScale(startScale, scaleDuration);
        mainCamera.transform.DOMove(new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z), scaleDuration).SetEase(Ease.InOutQuad);
        mainCamera.DOOrthoSize(2f, scaleDuration);
        locationTexts.SetActive(true);
        nameText.DOFade(1, 0.5f);
        yesButtonText.DOFade(1, 0.5f);
        noButtonText.DOFade(1, 0.5f);
    }

    public void LocationExitButton()
    {
        GameMenuScript.isFollowing = true;
        isSelect = false;
        mainCamera.transform.DOMove(new Vector3(0, 0, -10), scaleDuration).SetEase(Ease.InOutQuad);
        mainCamera.DOOrthoSize(5f, scaleDuration);
        locationTexts.SetActive(true);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(nameText.DOFade(0, 0.5f));
        sequence.Join(yesButtonText.DOFade(0, 0.5f));
        sequence.Join(noButtonText.DOFade(0, 0.5f));
        sequence.OnComplete(() => { locationTexts.SetActive(false); });
    }

    public void LoadLvl()
    {
        //loadPanelAsGameObject.SetActive(true);
        loadPanel.DOFade(1, 2).OnComplete(() => { SceneManager.LoadScene(sceneToLoad); }); 
    }
}
