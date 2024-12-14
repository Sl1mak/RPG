using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TownButtonScript : MonoBehaviour
{
    public float scaleUp = 1.1f, scaleDuration = 0.2f;

    private bool isSelect;

    private Vector3 startScale;

    public GameObject locations, townMenu;
    public Image loadPanel;
    public Camera mainCamera;

    private void Start()
    {
        startScale = transform.localScale;

        townMenu.SetActive(false);
        locations.SetActive(true);
    }

    public void OnPointerEnter() { transform.DOScale(startScale * scaleUp, scaleDuration); }

    public void OnPointerExit() { transform.DOScale(startScale, scaleDuration); }

    public void TownButtonClick() 
    {
        loadPanel.DOFade(1, 0.2f).OnComplete(() => { locations.SetActive(false); townMenu.SetActive(true); loadPanel.DOFade(0, 0.2f); mainCamera.transform.position = Vector3.zero; });
        GameMenuScript.isFollowing = false;
    }
}
