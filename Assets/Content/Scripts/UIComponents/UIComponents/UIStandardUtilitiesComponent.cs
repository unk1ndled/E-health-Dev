using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStandardUtilitiesComponent : UIAbstractComponent
{
    #region UI Elements

    [SerializeField]
    private GameObject uiPanel;

    [SerializeField]
    private Slider opacityInputField;

    [SerializeField]
    private Toggle interactToggle;

    [SerializeField]
    private Toggle traversalToggle;

    [SerializeField]
    private Button defaultButton;


    public event Action OnResetButtonClicked;
    public event Action<float> OnOpacityInputFieldChanged;
    public event Action<bool> OnInteractToggled;
    public event Action<bool> OnTraversalToggled;


    public void InitializeComponent()
    {
        opacityInputField.onValueChanged.AddListener(HandleOpacityInputFieldChange);
        interactToggle.onValueChanged.AddListener(HandleInteractToggled);
        traversalToggle.onValueChanged.AddListener(HandleTraversalToggled);
        defaultButton.onClick.AddListener(HandleDefaultButtonClicked);
    }
    #endregion

    public void HandleOpacityInputFieldChange(float value)
    {
         OnOpacityInputFieldChanged?.Invoke(value);
    }


    public void HandleInteractToggled(bool value)
    {
        OnInteractToggled?.Invoke(value);
    }

    public void HandleTraversalToggled(bool value)
    {
        OnTraversalToggled?.Invoke(value);
    }

    public void HandleDefaultButtonClicked()
    {
        OnResetButtonClicked?.Invoke();
    }

    public override void Hide()
    {
        base.Hide();
        uiPanel.gameObject.SetActive(false);
    }

    public override void Show()
    {
        base.Show();
        uiPanel.gameObject.SetActive(true);
    }
}
