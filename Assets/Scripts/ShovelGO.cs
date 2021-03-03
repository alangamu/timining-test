using System;
using UnityEngine;

public class ShovelGO : MonoBehaviour
{
    public event Action<Shovel, bool> OnShovelSelected;
    private Shovel shovel;

    private Outline outline;

    private void Awake()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    public void Setup(Shovel shovel)
    {
        this.shovel = shovel;
    }

    private void OnMouseEnter()
    {
        OnShovelSelected?.Invoke(shovel, true);
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        OnShovelSelected?.Invoke(shovel, false);
        outline.enabled = false;
    }
}
