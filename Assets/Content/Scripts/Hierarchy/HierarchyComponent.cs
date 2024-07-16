using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HierarchyComponent : MonoBehaviour
{
    private HierarchyNode root { get; set; }

    private List<HierarchyNode> currentLayer;
    private HierarchyNode legacyPivot;

    //Current Pivot will be set for mock purposes
    [SerializeField]
    private HierarchyNode currentPivot;
    // Start is called before the first frame update

    private static HierarchyComponent instance;

    public static HierarchyComponent Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<HierarchyComponent>();
                if (instance == null)
                {
                    GameObject managerObj = new GameObject("HierarchyManager");
                    instance = managerObj.AddComponent<HierarchyComponent>();
                }
            }
            return instance;
        }
    }

    public void SetRoot(Actor actor)
    {
        root = new HierarchyNode();
        root.SetNodeActor(actor);
    }

    public void SetCurrentPivot(HierarchyNode pivot)
    {
        currentPivot = pivot;
        UpdateLayerAndPriority();
        HideAndDisableAllParents(currentPivot);
        if (pivot.GetNodeActor().GetActorType() != ActorType.MICROSCOPIC)
        {
            HideAndDisableAllMicroscopic(root);
        }

    }

    private void HideAndDisableAllParents(HierarchyNode node)
    {
        HierarchyNode parent = node.Parent;
        while (parent != null)
        {
            SetNodeVisibility(parent, false);
            parent = parent.Parent;
        }

    }

    private void HideAndDisableAllChildren(HierarchyNode node)
    {
        foreach (var child in node.Children)
        {
            SetNodeVisibility(child, false);
            HideAndDisableAllChildren(child);
        }
    }

    private void HideAndDisableAllMicroscopic(HierarchyNode node)
    {
        if (node.nodeContent != null && node.nodeContent.GetActorType() == ActorType.MICROSCOPIC)
        {
            SetNodeVisibility(node, false);
        }
        foreach (var child in node.Children)
        {
            HideAndDisableAllMicroscopic(child);
        }
    }

    public void GetAllActors()
    {
        List<Actor> actors = new List<Actor>();
        actors.Add(root.GetNodeActor());
        foreach (var child in root.Children)
        {
            actors.Add(child.GetNodeActor());
        }
    }

    private void SetNodeVisibility(HierarchyNode node, bool visible)
    {
        if (node.nodeContent != null)
        {
            node.nodeContent.gameObject.SetActive(visible);
        }
        if (node.IsSubordinate && node.SubordinateActor != null)
        {
            node.SubordinateActor.gameObject.SetActive(visible);
        }
    }

    private void UpdateLayerAndPriority()
    {
        if (currentPivot.Parent != null)
        {
            currentLayer = currentPivot.Parent.Children;

            currentPivot.HasPriority = true;

            foreach (var node in currentLayer)
            {
                if (node != currentPivot)
                {
                    node.HasPriority = false;
                }
            }
        }
    }

    public List<HierarchyNode> GetCurrentLayer()
    {
        return currentLayer;
    }

    public HierarchyNode GetCurrentNode()
    {
        return currentPivot;
    }

    public void OnTransition(HierarchyNode newPivot)
    {
        if (newPivot.IsSubordinate)
        {
            if (!newPivot.Parent.IsSubordinate)
            {
                legacyPivot = currentPivot;
            }
            SetCurrentPivot(newPivot);
            SetNodeVisibility(newPivot, true);
            SetNodeVisibility(legacyPivot, true);
        }
        if (!newPivot.IsSubordinate)
        {
            SetCurrentPivot(newPivot);
            legacyPivot = null;
            HideAndDisableAllParents(newPivot);

        }
        //SET GEOMETRIC PIVOT
        //SET CUT AND LAYER FIXED
    }
}
