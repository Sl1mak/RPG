using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TownScript : MonoBehaviour
{
    public GameObject townMenu, locationsMenu;
    public Image loadPanel;

    public void FromTownToLocation() 
    { 
        loadPanel.DOFade(1, 0.2f).OnComplete(() => { locationsMenu.SetActive(true); townMenu.SetActive(false); loadPanel.DOFade(0, 0.2f); GameMenuScript.isFollowing = true; });
    }
}
