using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObservationController : UIController
{
    [SerializeField]
    private UIDescriptionComponent descriptionComponent;

    //[SerializeField]
    //private HierarchyComponent hierarchyComponent;

    //for mock only
    [SerializeField]
    private Actor currentActor;
    private ActorDataSO currentActorData;
    private enum DescriptionMode
    {
        Static, Autodisplay
    }


    private DescriptionMode descriptionMode;
    // Start is called before the first frame update

    private void Start()
    {
        PrepareUI();
    }

    public void PrepareUI()
    {
        descriptionComponent.OnDescriptionRequested += HandleDescriptionRequest;

        descriptionComponent.Show();
        //descriptionMode = DescriptionMode.Static;
        descriptionComponent.ResetDescription();

    }


    private void HandleDescriptionRequest()
    {
        currentActorData = currentActor.GetDataSO();
        if (currentActor && currentActorData)
        {
            descriptionComponent.SetDescription(currentActorData.name, currentActorData.description);
        }
    }

    public override void Activate()
    {
        base.Activate();
        descriptionComponent.UpdateDescription();
        FetchCurrentActor();
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }

    public void FetchCurrentActor()
    {
    }

    /*
    public void SetObservationMode(string title, string description, GameObject actor,
                                   bool autoDisplay, float displayDuration = 10f)
    {
        if (autoDisplay)
        {
            descriptionMode = DescriptionMode.Autodisplay;
            descriptionComponent.StartAutoDisplay(displayDuration);
        }
        else
        {
            descriptionMode = DescriptionMode.Static;
            descriptionComponent.StopAutoDisplay();
        }
    }
    public void ResetDescription()
    {
        descriptionComponent.ResetDescription();
        descriptionComponent.StopAutoDisplay();
    }
    */

    public override void OnTransition()
    {
        //ResetDescription();
        //List<HierarchyNode> currentLayer = GetCurrentLayer();
        //GetCurrentActor();
        //FillCurrentActorDescription();
        //AddRotation();
    }

    /*
    private List<HierarchyNode> GetCurrentLayer()
    {
        if ( hierarchyComponent == null )
        {
            Debug.LogError("Hierarchy Component is Not Set");
            return null;
        }

        return hierarchyComponent.GetCurrentLayer();
    }

    private void GetCurrentActor()
    {
        if ( hierarchyComponent == null )
        {
            Debug.LogError("Hierarchy Component is Not Set");
        }

        HierarchyNode currentNode = hierarchyComponent.GetCurrentNode();
        if ( currentNode == null )
        {
            Debug.LogError("Current Pivot is not set");
        }

        currentActor = currentNode.GetNodeActor();
        currentActorData = currentActor.GetDataSO();
    }


    private void AddRotation()
    {
        //FROM SHADER NOT HERE
    }
    */
}
