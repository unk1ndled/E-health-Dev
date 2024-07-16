using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    private RenderingComponent renderingComponent;
    private TransformComponent transformComponent;
    private AnimationComponent animationComponent;

    private List<AComponent> componentsList;

    [SerializeField]
    private ActorType actorType;

    [SerializeField]
    private ActorDataSO dataSO;

    [SerializeField]
    private LegendContainer legendContainer;

    [SerializeField]
    private List<GameObject> legendTargets;

    #region CUTS

    //[SerializeField]
    //private GameObject cutsContainer;

    //private List<Actor> cutsContent;

    //private Actor concernedActor;

    #endregion
    private void Awake()
    {
        componentsList = new List<AComponent>();
        //concernedActor = this;
    }

    private void Start()
    {
        Initialize();
        renderingComponent.enabled = false;
    }

    private void Initialize()
    {
        if (gameObject)
        {
            renderingComponent = GetComponent<RenderingComponent>();
            transformComponent = GetComponent<TransformComponent>();
            animationComponent = GetComponent<AnimationComponent>();

            if (renderingComponent == null)
            {
                gameObject.AddComponent<RenderingComponent>();
                renderingComponent = GetComponent<RenderingComponent>();
            }

            if (transformComponent == null)
            {
                gameObject.AddComponent<TransformComponent>();
                transformComponent = GetComponent<TransformComponent>();
            }

            if (animationComponent == null)
            {
                gameObject.AddComponent<AnimationComponent>();
                animationComponent = GetComponent<AnimationComponent>();
            }

            AddComponents();
            InitializeComponents();
            //InitializeCuts();
        }
    }

    /*
    private void InitializeCuts()
    {
        if (cutsContent == null)
        {
            cutsContent = new List<Actor>();
        }

        cutsContent.Clear();
        Actor[] actorsInCutsContainer = cutsContainer.GetComponentsInChildren<Actor>();

        cutsContent.AddRange(actorsInCutsContainer);
    }
    */

    private void AddComponents()
    {
        componentsList.Add(renderingComponent);
        componentsList.Add(transformComponent);
        componentsList.Add(animationComponent);
    }

    private void RemoveComponent(AComponent component)
    {
        if (componentsList.Contains(component))
        {
            componentsList.Remove(component);
        }
        else
        {
            Debug.LogWarning("The Component to Remove was not found ! ");
        }
    }

    private void InitializeComponents()
    {
        foreach (AComponent component in componentsList)
        {
            component.Initialize();
        }
    }

    public ActorType GetActorType()
    {
        return actorType;
    }

    public ActorDataSO GetDataSO()
    {
        return dataSO;
    }

    public void ShowLegend()
    {
        if (legendContainer != null && legendTargets != null)
        {
            legendContainer.ShowLegendItems(legendTargets);
        }
    }

    public void HideLegend()
    {
        if (legendContainer != null)
        {
            legendContainer.HideLegendItems();
        }
    }

    public AnimationComponent GetAnimationComponent()
    {
        return animationComponent;
    }

    public void SetCurrentAnimation(AnimationClip animationClip)
    {
        if (animationComponent != null)
        {
            animationComponent.SetCurrentAnimation(animationClip.name);
        }
    }

    public TransformComponent GetTransformComponent()
    {
        return transformComponent;
    }

    public RenderingComponent GetRenderingComponent()
    {
        return renderingComponent;
    }
}
