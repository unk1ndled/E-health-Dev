using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStandardController : UIController
{
    //[SerializeField]
    //private HierarchyComponent hierarchyComponent;

    [SerializeField]
    private List<Actor> actors;

    [SerializeField]
    private UIStandardUtilitiesComponent utilitiesComponent;
    private TransformStateManager transformStateManager;

    #region Mock
    [SerializeField]
    private TextMeshProUGUI mockText;

    [SerializeField]
    private UIButtonComposite buttonComposite;

    private Dictionary<string, Action> buttonActions = new Dictionary<string, Action>();

    #endregion

    #region Fetchers 

    [SerializeField]
    private UISearchComponent cutsComponent;
    [SerializeField]
    private UISearchComponent layersComponent;

    private Actor currentActor;
    private List<Actor> currentLayer;

    private List<UISearchComponent> fetchComponents;

    public int mockSize = 2;

    #endregion

    private void Start()
    {
        transformStateManager = TransformStateManager.Instance;
        PrepareUI();

    }

    private void PrepareUI()
    {
        utilitiesComponent.InitializeComponent();
        utilitiesComponent.OnInteractToggled += HandleInteractToggle;
        utilitiesComponent.OnOpacityInputFieldChanged += HandleOpacityInput;
        utilitiesComponent.OnResetButtonClicked += HandleResetButtonClick;
        utilitiesComponent.OnTraversalToggled += HandleTraversalToggle;

        buttonComposite.InitializeUI();
        PrepareButtonsEvents();

        cutsComponent.InitializeComponentUI(mockSize);
        layersComponent.InitializeComponentUI(mockSize);
        cutsComponent.OnItemClickRequested += HandleCutItemClick;
        layersComponent.OnItemClickRequested += HandleLayerItemClick;

        fetchComponents.Add(cutsComponent);
        fetchComponents.Add(layersComponent);
    }


    private Action GetButtonAction(string buttonName)
    {
        switch (buttonName)
        {
            case "Cuts": return HandleCutsClick;
            case "Legend": return HandleLegendClick;
            case "Layers": return HandleLayersClick;
            default: return HandleButtonCompositeError;
        }
    }

    private void PrepareButtonsEvents()
    {
        List<UIButton> fetchedButtons = buttonComposite.GetAllButtons();

        foreach (UIButton button in fetchedButtons)
        {
            Action buttonAction = GetButtonAction(button.buttonName);
            buttonActions[button.buttonName] = buttonAction;
            button.OnItemClicked += buttonActions[button.buttonName];
        }
    }

    private void HandleOpacityInput(float input)
    {
        mockText.SetText($"Opacity handle debug succesful" + input);
    }

    private void HandleResetButtonClick()
    {
        mockText.SetText($"Reset Button debug succesful");
    }

    private void HandleTraversalToggle(bool toggle)
    {
        mockText.SetText($"Traversal handle debug succesful" + toggle);
    }

    private void HandleInteractToggle(bool toggle)
    {
        mockText.SetText($"Interact handle debug succesful" + toggle);
    }


    private void HandleCutsClick()
    {
        mockText.SetText($"Cuts handle debug succesful");
    }

    private void HandleLegendClick()
    {
        mockText.SetText($"Legend handle debug succesful");
    }

    private void HandleLayersClick()
    {
        mockText.SetText($"Layers handle debug succesful");
    }

    private void HandleButtonCompositeError()
    {
        mockText.SetText($"There is an error with the composite check your code");
    }


    private void HandleCutItemClick(int index)
    {
        mockText.SetText($"You have clicked on" + GetItemAt(index, cutsComponent));
    }

    private void HandleLayerItemClick(int index)
    {
        mockText.SetText($"You have clicked on" + index);
    }

    public void ShowLegendsForAllActors()
    {
        foreach (var actor in actors)
        {
            actor.ShowLegend();
        }
    }

    public void HideLegendsForAllActors()
    {
        foreach (var actor in actors)
        {
            actor.HideLegend();
        }
    }

    private void OnActorChange()
    {
        //Changing legend container
        //Reseting transform values of previous actor 
        //UpdateFetcherUI();
    }

    private void UpdateFetcherUI(Dictionary<int, string> fetcherStrings, UISearchComponent fetchComponent)
    {
        fetchComponent.ResetAllItems();
        foreach (var item in fetcherStrings)
        {

            fetchComponent.UpdateData(item.Key, item.Value);
        }

    }

    private UISearchItem GetItemAt(int itemIndex, UISearchComponent fetchComponent)
    {
        return fetchComponent.listOfItems[itemIndex];
    }

    public override void Activate()
    {
        base.Activate();
        utilitiesComponent.Show();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        utilitiesComponent.Hide();
    }
    public override void OnTransition()
    {

    }

}
