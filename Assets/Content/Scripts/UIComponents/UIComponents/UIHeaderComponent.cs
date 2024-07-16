using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHeaderComponent : UIAbstractComponent
{
    public enum HeaderState
    {
        Standard,
        Observation,
        Animation,
        Drawing,
        Video
    }

    [SerializeField]
    private GameObject headerPanel;

    [SerializeField]
    private List<UIHeaderElement> headerElements;

    private HeaderState currentState;

    public delegate void HeaderStateChangeHandler(HeaderState newState);
    public event HeaderStateChangeHandler OnHeaderStateChanged;

    public void SetDefaultSettings()
    {
        currentState = HeaderState.Standard;
    }
    public void InitializeHeaderElements()
    {
        foreach (var element in headerElements)
        {
            element.Initialize(this);
        }
    }

    public void HandleHeaderElementSelection(UIHeaderElement selectedElement)
    {
        foreach (var element in headerElements)
        {
            if (element == selectedElement)
            {
                element.Select();

            }
            else
            {
                element.Deselect();
            }
        }

        ChangeHeaderState(selectedElement.State);
    }

    private void ChangeHeaderState(HeaderState newState)
    {
        currentState = newState;
        OnHeaderStateChanged?.Invoke(newState);
        //UIStateManager code
    }

    public override void Show()
    {
        base.Show();
    }

    private void UpdateHeaderHighlight()
    {
    }


}
