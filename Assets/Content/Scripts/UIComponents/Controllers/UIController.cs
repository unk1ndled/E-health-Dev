using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIController : MonoBehaviour
{
    public bool isActive;

    public abstract void OnTransition();

    public virtual void Activate()
    {
        isActive = true;
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        isActive = false;
        gameObject.SetActive(false);
    }



}
