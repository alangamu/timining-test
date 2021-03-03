using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the interaction with the shovels,
/// Show and hide the shovel information
/// </summary>
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

    /// <summary>
    /// Add the listeners for the shovels
    /// </summary>
    /// <param name="obj">list of shovels in scene</param>
    private void ShovelManager_OnShovelsReady(List<ShovelGO> obj)
    {
        foreach (var item in obj)
        {
            item.OnShovelSelected += Item_OnShovelSelected;
        }
    }

    /// <summary>
    /// Action of shovel selection
    /// </summary>
    /// <param name="shovel">interacting shovel</param>
    /// <param name="isShowing">display or hide the information</param>
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

    /// <summary>
    /// Activate and settp the info window
    /// </summary>
    /// <param name="shovel">active shovel</param>
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

    /// <summary>
    /// Add growing effect to the info window
    /// </summary>
    private void TweenEffect()
    {
        LeanTween.cancel(shovelInfoWindow);

        shovelInfoWindow.transform.localScale = Vector3.one;

        LeanTween.scale(shovelInfoWindow, Vector3.one * 1.3f, tweenTime);
    }

}
