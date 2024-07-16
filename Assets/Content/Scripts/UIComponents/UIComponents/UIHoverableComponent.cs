using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHoverableComponent : MonoBehaviour, IHoverable
{
    public bool IsHovering { get; private set; }

    [SerializeField]
    private string hoverText;

    private void OnInteractOn()
    {
        IsHovering = true;
    }

    private void OnInteractOff()
    {
        IsHovering = false;
    }
    public string GetHoverText()
    {
        return hoverText;
    }

}
