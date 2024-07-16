using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHeaderElement : UIAbstractComponent
{

    [SerializeField]
    private UIHeaderComponent.HeaderState state;

    private Button button;

    private UIHeaderComponent headerComponent;


    public UIHeaderComponent.HeaderState State => state;

    public void Initialize(UIHeaderComponent headerComponent)
    {
        this.headerComponent = headerComponent;
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnElementClicked);
        SetColor();
    }

    private void OnElementClicked()
    {
        headerComponent.HandleHeaderElementSelection(this);
    }

    private void SetColor()
    {

    }

    public void Select()
    {

    }

    public void Deselect()
    {

    }
}
