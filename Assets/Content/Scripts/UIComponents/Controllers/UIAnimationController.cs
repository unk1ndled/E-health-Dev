using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationController : UIController
{

    [SerializeField]
    private UIAnimationToolbarComponent toolbarComponent;

    private Actor currentActor;

    public event Action<AnimationClip> OnSimulationSelected;


    public void PrepareUI()
    {
        if (toolbarComponent)
        {
            toolbarComponent.Show();
            toolbarComponent.InitializeToolbar();
        }

    }

    #region Subscription



    private void ToolbarSubscription()
    {
        toolbarComponent.OnFrameSliderChanged += HandleFrameSliderChanged;
        toolbarComponent.OnFrameInputFieldChanged += HandleFrameInputFieldChanged;
        toolbarComponent.OnSpeedInputFieldChanged += HandleSpeedInputFieldChanged;
        toolbarComponent.OnObservationModeToggled += HandleObservationModeToggled;
        toolbarComponent.OnDisplayLegendToggled += HandleDisplayLegendToggled;
        toolbarComponent.OnAllowLoopbackToggled += HandleAllowLoopbackToggled;
    }

    private void OnEnable()
    {
        ToolbarSubscription();
    }

    #endregion

    #region Desubscription


    private void ToolbarDesubscription()
    {
        toolbarComponent.OnFrameSliderChanged -= HandleFrameSliderChanged;
        toolbarComponent.OnFrameInputFieldChanged -= HandleFrameInputFieldChanged;
        toolbarComponent.OnSpeedInputFieldChanged -= HandleSpeedInputFieldChanged;
        toolbarComponent.OnObservationModeToggled -= HandleObservationModeToggled;
        toolbarComponent.OnDisplayLegendToggled -= HandleDisplayLegendToggled;
        toolbarComponent.OnAllowLoopbackToggled -= HandleAllowLoopbackToggled;
    }
    private void OnDisable()
    {
        ToolbarDesubscription();
    }

    #endregion

    #region Handles Box Component
    private void HandleViewportModeClicked()
    {
        Debug.Log("Viewport Mode Button Clicked");
    }

    private void HandleCurrentSimulation()
    {
        Debug.Log("Current simulation button clicked");
    }

    private void HandleVisualiseGraph()
    {
        Debug.Log("Visualise graph button clicked");
    }


    #endregion

    #region Handles Animation Toolbar Component

    private void HandleFrameSliderChanged(float value)
    {
        if (currentActor != null)
        {
            currentActor.GetAnimationComponent().SetCurrentTime(value);
        }
        Debug.Log($"Frame slider changed to : {value}");
    }

    private void HandleFrameInputFieldChanged(int value)
    {
        if (currentActor != null)
        {
            float time = value / currentActor.GetAnimationComponent().GetFrameRate();
            currentActor.GetAnimationComponent().SetCurrentTime(value);
        }
        Debug.Log($"Frame input field changed to :{value}");
        //TODO : CHANGING FRAMESLIDER TOO
    }

    private void HandleSpeedInputFieldChanged(float value)
    {
        if (currentActor != null)
        {
            currentActor.GetAnimationComponent().SetSpeed(value);
        }
        Debug.Log($"Speed input field changed to: {value}");

    }

    private void HandleObservationModeToggled(bool value)
    {
        if (currentActor != null)
        {
            currentActor.GetAnimationComponent().SetObservationMode(value);
            if (value == true)
            {
                currentActor.GetAnimationComponent().Resume();
            }
            else
            {
                currentActor.GetAnimationComponent().Pause();
            }
        }
        Debug.Log($"Observation mode toggled: {value}");

    }

    private void HandleDisplayLegendToggled(bool value)
    {
        Debug.Log($"Display legend toggled: {value}");
        // Implement the functionality for toggling the display of legends
    }

    private void HandleAllowLoopbackToggled(bool value)
    {
        if (currentActor != null)
        {
            currentActor.GetAnimationComponent().SetLoop(value);
        }
        Debug.Log($"Allow Loopback Toggled : {value}");
    }

    #endregion

    public void SetCurrentAnimationClip(AnimationClip animationClip)
    {
        currentActor.GetAnimationComponent().SetCurrentAnimation(animationClip.name);
    }

    public override void OnTransition()
    {
    }


}
