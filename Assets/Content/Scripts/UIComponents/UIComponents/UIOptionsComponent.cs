using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIOptionsComponent : UIAbstractComponent
{
    #region UI Elements

    private string currentMode;

    [SerializeField]
    private GameObject optionsPanel;

    [SerializeField]
    private List<Button> optionsButtons;

    [SerializeField]
    private GameObject itemsPanel;

    [SerializeField]
    private List<Button> itemButtons;

    private List<OptionDataSO> optionDataList;

    #endregion


    #region Data and Events
    private Dictionary<string, List<string>> optionDataDictionary;

    public delegate void ItemSelectedHandler(string itemName);
    public event ItemSelectedHandler OnItemSelected;

    #endregion

    public delegate void AnimationSelectedHandler(string animationName);
    public event AnimationSelectedHandler OnSelectAnimation;
    // Start is called before the first frame update


    public void InitializeOptionData()
    {
        currentMode = "";
        optionDataDictionary = new Dictionary<string, List<string>>();
        foreach ( var data in optionDataList )
        {
            foreach ( var option in data.optionDataList)
            {
                if ( !optionDataDictionary.ContainsKey(option.optionName)) {

                    optionDataDictionary.Add(option.optionName, option.items);
                }
            }
        }
    }

    public void InitializeOptionButtons()
    {
        foreach( var button in optionsButtons )
        {
            button.onClick.AddListener( 
                () => OnOptionButtonClicked(button.GetComponentInChildren<TextMeshProUGUI>().text));
        }
    }

    private void OnOptionButtonClicked(string optionName)
    {
        if ( optionDataDictionary.TryGetValue(optionName, out List<string> items))
        {
            //HIDE PREVIOUS BUTTONS AND PANEL
            optionsPanel.SetActive(false);
            itemsPanel.SetActive(true);
            PopulateItemsPanel(items);
            currentMode = optionName;
        }
    }

    private void PopulateItemsPanel(List<string> items )
    {
        for ( int i = 0; i < itemButtons.Count; i ++ )
        {
            if ( i < items.Count)
            {
                itemButtons[i].gameObject.SetActive(true);
                itemButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = items[i];
                itemButtons[i].onClick.RemoveAllListeners();
                itemButtons[i].onClick.AddListener(() => OnItemSelected?.Invoke(items[i]));
            }
            else
            {
                itemButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void SetTitle(string newTitle)
    {
        //???
    }

    public override void Hide()
    {
        base.Hide();
        optionsPanel.SetActive(false);
        itemsPanel.SetActive(false);
        
    }

    public override void Show()
    {
        base.Show();
        optionsPanel.SetActive(true);
        itemsPanel.SetActive(true);
    }

    public string GetCurrentMode()
    {
        return currentMode;
    }
}
