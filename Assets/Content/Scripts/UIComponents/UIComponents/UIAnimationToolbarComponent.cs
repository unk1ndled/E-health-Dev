using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimationToolbarComponent : UIAbstractComponent
{
    #region UI Elements

    [SerializeField]
    private GameObject UIPanel;

    [SerializeField]
    private Slider frameSlider;

    [SerializeField]
    private TMP_InputField frameInputField;

    [SerializeField]
    private TMP_InputField speedInputField;

    [SerializeField]
    private Toggle observationModeToggle;

    [SerializeField]
    private Toggle displayLegendToggle;

    [SerializeField]
    private Toggle allowLoopbackToggle;

    #endregion


    #region Events

    public event Action<float> OnFrameSliderChanged;
    public event Action<int> OnFrameInputFieldChanged;
    public event Action<float> OnSpeedInputFieldChanged;
    public event Action<bool> OnObservationModeToggled;
    public event Action<bool> OnDisplayLegendToggled;
    public event Action<bool> OnAllowLoopbackToggled;

    #endregion

    public void InitializeToolbar()
    {
        frameSlider.onValueChanged.AddListener(HandleFrameSliderChange);
        frameInputField.onEndEdit.AddListener(HandleFrameInputFieldChange);
        speedInputField.onEndEdit.AddListener(HandleSpeedInputFieldChange);
        observationModeToggle.onValueChanged.AddListener(HandleObservationModeToggled);
        displayLegendToggle.onValueChanged.AddListener(HandleDisplayLegendToggled);
        allowLoopbackToggle.onValueChanged.AddListener(HandleAllowLoopbackToggled);
    }

    public void HandleFrameSliderChange(float value)
    {
        OnFrameSliderChanged?.Invoke(value);
    }

    public void HandleFrameInputFieldChange(string value)
    {
        if ( int.TryParse(value, out int intValue))
        {
            OnFrameInputFieldChanged?.Invoke(intValue);
        }
    }

    public void HandleSpeedInputFieldChange(string value)
    {
        if ( int.TryParse(value, out int intValue))
        {
            OnSpeedInputFieldChanged?.Invoke(intValue);
        }
    }

    public void HandleObservationModeToggled(bool value)
    {
        OnObservationModeToggled?.Invoke(value);
    }

    public void HandleDisplayLegendToggled(bool value)
    {
        OnDisplayLegendToggled?.Invoke(value);
    }

    public void HandleAllowLoopbackToggled(bool value)
    {
        OnAllowLoopbackToggled?.Invoke(value);
    }

    public override void Hide()
    {
        base.Hide();
        UIPanel.SetActive(false);
    }

    public override void Show()
    {
        base.Show();
        UIPanel.SetActive(false);
    }
}
