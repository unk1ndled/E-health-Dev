using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TO CHANGE ABSOLUETLY !! 
public class UIPopUpComponent : UIAbstractComponent
{
    [SerializeField]
    private GameObject popupPanel;

    [SerializeField]
    private Button actionButtonPrefab;

    public event Action<int> OnActionSelected;

    public void SetPopUpContent(string[] actionNames)
    {
        ClearButtons();
        for ( int i =0; i < actionNames.Length; i ++)
        {
            Button actionButton = Instantiate(actionButtonPrefab, popupPanel.transform);
            int index = i;
            actionButton.onClick.AddListener(() => HandleActionClick(index));
            actionButton.GetComponentInChildren<Text>().text = actionNames[i];
        }
    }
    


    private void ClearButtons()
    {
        foreach ( Transform child in popupPanel.transform )
        {
            Destroy(child.gameObject);
        }
    }

    public override void Hide()
    {
        base.Hide();
    }

    public override void Show()
    {
        base.Show();
    }

    private void HandleActionClick(int index)
    {
        OnActionSelected?.Invoke(index);
        Hide();
    }
}
