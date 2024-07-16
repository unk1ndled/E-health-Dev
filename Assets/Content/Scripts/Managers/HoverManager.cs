using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverManager : MonoBehaviour
{
    [SerializeField]
    private GameObject hoverUIPrefab;

    private GameObject hoverUIInstance;
    private IHoverable currentHoverable;
    private Coroutine hoverCoroutine;

    private float hoverStartTime = 1.5f;

    private void Update()
    {
        DetectHoverable();
    }

    private void DetectHoverable()
    {
        //TO FILL WITH XR FUNCTIONALITY
        /*
         * if (currentHoverable != null && !currentHoverable.IsHovering)
        {
            StopHover();
        }
        GameObject uiElementUnderCursor = GetUIElementUnderCursor();

        if (uiElementUnderCursor != null)
        {
            IHoverable hoverable = uiElementUnderCursor.GetComponent<IHoverable>();
            if (hoverable != null)
            {
                if (currentHoverable != hoverable)
                {
                    currentHoverable = hoverable;
                    StartHover();
                }
            }
            else
            {
                StopHover();
            }
        }
        else
        {
            StopHover();
        }
         */
    }

    private void StartHover()
    {
        if ( hoverCoroutine != null )
        {
            StopCoroutine(hoverCoroutine);
        }

        hoverCoroutine = StartCoroutine(DisplayHoverUI(currentHoverable));
    }

    private IEnumerator DisplayHoverUI(IHoverable hoverable)
    {
        yield return new WaitForSeconds(hoverStartTime);

        if ( hoverable.IsHovering )
        {
            if (hoverUIInstance == null )
            {
                hoverUIInstance = Instantiate(hoverUIPrefab, transform);
            }

            var hoverUI = hoverUIInstance.GetComponent<UIHover>();
            if ( hoverUI != null )
            {
                hoverUI.SetText(hoverable.GetHoverText());
            }
        }
    }

    private void StopHover()
    {
        if ( hoverCoroutine != null )
        {
            StopCoroutine(hoverCoroutine);
            hoverCoroutine = null;
        }

        if (hoverUIInstance != null )
        {
            Destroy(hoverUIInstance);
            hoverUIInstance = null;
        }

        currentHoverable = null;
    }

    private GameObject GetUIElementUnderCursor()
    {
        //ToDo
        //raycasting etc to get UI Element under raycast. this must be filled according to XR 
        return null;
    }
}
