using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject shovelInfoWindow;
    [SerializeField] private float tweenTime;

    private ShovelManager shovelManager;

    private void Awake()
    {
        shovelManager = FindObjectOfType<ShovelManager>();
        CloseShovelInfoWindow();
    }

    private void Start()
    {
        shovelManager.OnShovelsReady += ShovelManager_OnShovelsReady;
    }

    private void ShovelManager_OnShovelsReady(List<ShovelGO> obj)
    {
        foreach (var item in obj)
        {
            item.OnShovelSelected += Item_OnShovelSelected;
        }
    }

    private void Item_OnShovelSelected(Shovel shovel, bool isShowing)
    {
        if (isShowing)
        {
            ShowShovelInfoWindow(shovel);
        }
        else
        {
            CloseShovelInfoWindow();
        }
    }

    private void ShowShovelInfoWindow(Shovel shovel)
    {
        shovelInfoWindow.SetActive(true);
        shovelInfoWindow.GetComponent<ShovelInfo>().Setup(shovel);
        TweenEffect();
    }

    private void CloseShovelInfoWindow()
    {
        shovelInfoWindow.SetActive(false);
    }

    private void TweenEffect()
    {
        LeanTween.cancel(shovelInfoWindow);

        shovelInfoWindow.transform.localScale = Vector3.one;

        LeanTween.scale(shovelInfoWindow, Vector3.one * 1.3f, tweenTime);
    }

}
