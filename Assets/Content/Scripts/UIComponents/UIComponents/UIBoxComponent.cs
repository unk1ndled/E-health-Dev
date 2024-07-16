using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBoxComponent : UIAbstractComponent
{
    [SerializeField]
    private GameObject boxPanel;

    private bool isFirst;

    [SerializeField]
    private List<UIBoxElement> boxElements;

    private List<string> boxNames;

 
    public void InitializeBoxElements()
    {
        foreach ( var element in boxElements )
        {
            element.Initialize(this);
        }
    }

    public void HandleBoxElementSelection(UIBoxElement selectedElement)
    {
        if (isFirst)
        {
            selectedElement.OnElementClicked?.Invoke();
        }
        else
        {

            selectedElement.OnHandlerClicked?.Invoke(selectedElement.name);
        }
    }

    public List<UIBoxElement> GetBoxElements()
    {
        return boxElements;
    }

    public List<string> GetBoxNames()
    {
        foreach ( var element in boxElements)
        {
            boxNames.Add(element.name);
        }
        return boxNames;
    }

    public void SetIsFirst(bool toggle)
    {
        isFirst = toggle;
    }
}
