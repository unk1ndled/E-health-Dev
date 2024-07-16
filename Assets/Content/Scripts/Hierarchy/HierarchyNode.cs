using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HierarchyNode
{
    internal HierarchyNode Parent { get; set; }
    internal Actor nodeContent { get; set; }
    internal List<HierarchyNode> Children { get; set; }
    internal bool HasPriority { get; set; }
    internal bool IsSubordinate { get; set; }
    internal Actor SubordinateActor { get; set; }
    // Start is called before the first frame update
    public HierarchyNode()
    {
        Children = new List<HierarchyNode>();
        nodeContent = null;
        IsSubordinate = false;
        SubordinateActor = null;
    }

    public void AddChild(HierarchyNode child)
    {
        if (child != null && !Children.Contains(child))
        {
            Children.Add(child);
            child.SetParent(this);
        }
    }

    public void RemoveChild(HierarchyNode child)
    {
        if (child != null & !Children.Contains(child))
        {
            Children.Remove(child);
            child.SetParent(null);
        }

    }

    public void SetParent(HierarchyNode parent)
    {
        Parent = parent;
    }

    public void SetNodeActor(Actor actor)
    {
        nodeContent = actor;
    }

    public Actor GetNodeActor()
    {
        return nodeContent;
    }

    public void SetSubordinateActor(Actor actor)
    {
        IsSubordinate = true;
        SubordinateActor = actor;
    }

    public Actor GetSubordinateActor()
    {
        return SubordinateActor;
    }
}
