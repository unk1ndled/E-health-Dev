using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void OnInteract();
    public void OnHighlight();
    public void OnUnhighlight();
}
