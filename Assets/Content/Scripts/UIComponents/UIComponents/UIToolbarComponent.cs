using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIToolbarComponent : UIAbstractComponent
{
    #region UI Elements
    [SerializeField]
    private GameObject toolbarPanel;

    [SerializeField]
    private List<Button> buttons;

    [SerializeField]
    private TextMeshProUGUI title;

    [SerializeField]
    private List<ToolbarButtonConfiguration> buttonConfigurations;

    [SerializeField]
    private UIPopUpComponent popUpComponent;

    public ToolbarType toolbarType;

    #endregion

    public delegate void ToolbarButtonClickHandler(string buttonName);
    public event ToolbarButtonClickHandler OnToolbarButtonClick;

    private Dictionary<string, ToolbarButtonConfiguration> configurationDictionary;


    
    public void InitializeButtonConfigurations()
    {
        configurationDictionary = new Dictionary<string, ToolbarButtonConfiguration>();
        foreach ( var config in buttonConfigurations )
        {
            if ( !configurationDictionary.ContainsKey(config.configurationKey))
            {
                configurationDictionary.Add(config.configurationKey, config);
            }
        }
    }

    public void UpdateToolbarButtons(string configurationKey)
    {
        if ( configurationDictionary.TryGetValue(configurationKey, out ToolbarButtonConfiguration config))
        {
            for (int i = 0; i < buttons.Count; i++ )
            {
                if ( i < config.buttonNames.Count )
                {
                    buttons[i].gameObject.SetActive(true);
                    buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = config.buttonNames[i];
                    buttons[i].onClick.RemoveAllListeners();
                    buttons[i].onClick.AddListener(() => HandleToolbarButtonClick(config, config.buttonNames[i]));
                }
                else
                {
                    buttons[i].gameObject.SetActive(false);
                }
            }
        }
    }

    public void SetTitle(string newTitle)
    {
        title.text = newTitle;
    }

    public override void Hide()
    {
        base.Hide();
        toolbarPanel.SetActive(false);
    }

    public override void Show()
    {
        base.Show();
        toolbarPanel.SetActive(true);
    }


    //TO ADD IN CONTROLLER

    public void HandleToolbarButtonClick(ToolbarButtonConfiguration config, string buttonName)
    {
        if ( toolbarType == ToolbarType.WithPopUp)
        {
            popUpComponent.SetPopUpContent(config.popupButtonNames.ToArray());
            popUpComponent.Show();
        }
        else
        {
            OnToolbarButtonClick?.Invoke(buttonName);
        }
    }
}
