using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonComposite : UIAbstractComponent
{
    [SerializeField]
    private GameObject container;

    private List<UIButton> listOfButtons = new List<UIButton>();


    public void InitializeUI()
    {
        FetchButtons();
    }

    public void FetchButtons()
    {
        foreach (Transform child in container.transform)
        {
            UIButton button = child.GetComponent<UIButton>();
            if (button != null)
            {
                listOfButtons.Add(button);
            }
        }
    }

    public List<UIButton> GetAllButtons()
    {
        return listOfButtons;
    }
    public override void Show()
    {
        base.Show();
    }

    public override void Hide()
    {
        base.Hide();
    }
}
