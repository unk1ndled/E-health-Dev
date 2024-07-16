using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBoxElement : UIAbstractComponent
{
    public enum BoxState
    {
        STANDARD_Edit,
        STANDARD_Memo,
        ViewportMode,
        CurrentSimulation,
        VisualiseGraph,

    }


    [SerializeField]
    public BoxState boxState;

    private Button button;


    public Action OnElementClicked { get; set; }
    public Action<string> OnHandlerClicked { get; set; }

    private UIBoxComponent boxComponent;

    public void Initialize(UIBoxComponent boxComponent)
    {
        this.boxComponent = boxComponent;
        button = GetComponent<Button>();
        SetColor();
        button.onClick.AddListener(() => boxComponent.HandleBoxElementSelection(this));
  
    }

    private void SetColor()
    {

    }
}
