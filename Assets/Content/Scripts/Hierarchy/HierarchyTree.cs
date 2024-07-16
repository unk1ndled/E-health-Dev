using UnityEngine;

public class HierarchyTree : MonoBehaviour
{
    private HierarchyComponent hierarchyComponent;

    private void Awake()
    {
        // VERY BAD SHOULD BE HANDLED IN ITS OWN CLASS
        hierarchyComponent = GetComponent<HierarchyComponent>();
        SetupHierarchyTree();
    }

    private void SetupHierarchyTree()
    {
        // Find the root actor (e.g., Body) in the scene
        Actor rootActor = FindRootActor();
        if (rootActor == null)
        {
            Debug.LogError("Root Actor not found!");
            return;
        }

        // Create the root node
        HierarchyNode rootNode = new HierarchyNode { nodeContent = rootActor };
        hierarchyComponent.SetRoot(rootActor);

        // Recursively build the hierarchy
        BuildHierarchy(rootNode, rootActor.transform);

        // Set the root node in the HierarchyComponent
        hierarchyComponent.SetCurrentPivot(rootNode);
    }

    private Actor FindRootActor()
    {
        // Assuming the root actor is the one without a parent
        Actor[] allActors = FindObjectsOfType<Actor>();
        foreach (var actor in allActors)
        {
            if (actor.transform.parent == null)
            {
                return actor;
            }
        }
        return null;
    }

    private void BuildHierarchy(HierarchyNode parentNode, Transform parentTransform)
    {
        foreach (Transform childTransform in parentTransform)
        {
            Actor childActor = childTransform.GetComponent<Actor>();
            if (childActor != null)
            {
                HierarchyNode childNode = new HierarchyNode { nodeContent = childActor };
                parentNode.AddChild(childNode);
                BuildHierarchy(childNode, childTransform);
            }
        }
    }
}