using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : UIAbstractComponent
{

    private Button button;

    public event Action OnItemClicked;

    public event Action OnFetchRequested;

    public string buttonName;

    public Text buttonNameText;

    [SerializeField]
    private ButtonType buttonType;
    // Start is called before the first frame update
    public void Awake()
    {
        button = GetComponent<Button>();
        buttonNameText.text = buttonName;
        button.onClick.AddListener(OnButtonClicked);
    }


    public void OnButtonClicked()
    {
        switch (buttonType)
        {
            case (ButtonType.FETCHER):
                OnFetchRequested?.Invoke();
                break;
            case (ButtonType.TRIGGER):
                OnItemClicked?.Invoke();
                break;
        }
    }

    public override void Show()
    {
        base.Show();
    }

    public override void Hide()
    {
        base.Hide();
    }

    public enum ButtonType
    {
        FETCHER,
        TRIGGER,
    }

}
