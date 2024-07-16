using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class UIStateManager : MonoBehaviour
{

    public UIStandardController standardController;

    public UIObservationController observationController;

    public UIAnimationController animationController;

    public UIDrawingController drawingController;

    public UIVideoController videoController;

    //private UIVideoController videoController;

    public List<UIController> listOfControllers;

    [SerializeField]
    private UIHeaderComponent headerComponent;

    //Debug

    public TextMeshProUGUI text;



    private void Initialize()
    {
        FetchControllers();
        ActivateController<UIStandardController>();
    }

    private void FetchControllers()
    {
        listOfControllers = Resources.FindObjectsOfTypeAll<UIController>().ToList();

        drawingController = listOfControllers.OfType<UIDrawingController>().FirstOrDefault();
        standardController = listOfControllers.OfType<UIStandardController>().FirstOrDefault();
        animationController = listOfControllers.OfType<UIAnimationController>().FirstOrDefault();
        observationController = listOfControllers.OfType<UIObservationController>().FirstOrDefault();
        videoController = listOfControllers.OfType<UIVideoController>().FirstOrDefault();
        //videoController = listOfControllers.OfType<UIVideoController>().FirstOrDefault();
    }


    private void OnEnable()
    {
        Initialize();
        headerComponent.InitializeHeaderElements();
        headerComponent.SetDefaultSettings();
        headerComponent.OnHeaderStateChanged += HandleHeaderStateChanged;
    }

    private void OnDisable()
    {
        headerComponent.OnHeaderStateChanged -= HandleHeaderStateChanged;
    }


    private void HandleHeaderStateChanged(UIHeaderComponent.HeaderState headerState)
    {
        Debug.Log("Entering event section");
        var activeController = listOfControllers.FirstOrDefault(c => c.isActive);
        activeController?.OnTransition();

        DeactivateAllControllers();

        switch (headerState)
        {
            case UIHeaderComponent.HeaderState.Standard:
                text.text = "STANDARD CONTROLLER ACTIVATED";
                ActivateController<UIStandardController>();
                //standardController.PrepareUI();
                break;
            case UIHeaderComponent.HeaderState.Drawing:
                ActivateController<UIDrawingController>();
                //drawingController.PrepareUI();
                text.text = "DRAWING CONTROLLER ACTIVATED";
                break;
            case UIHeaderComponent.HeaderState.Observation:
                ActivateController<UIObservationController>();
                //observationController.PrepareUI();
                text.text = "OBSERVATION CONTROLLER ACTIVATED";
                break;
            case UIHeaderComponent.HeaderState.Animation:
                //animationController.PrepareUI();
                ActivateController<UIAnimationController>();
                text.text = "ANIMATION CONTROLLER ACTIVATED";
                break;
            case UIHeaderComponent.HeaderState.Video:
                ActivateController<UIVideoController>();
                text.text = "VIDEO CONTROLLER ACTIVATED";
                break;
        }
    }

    private void DeactivateAllControllers()
    {
        foreach (UIController controller in listOfControllers)
        {
            controller.Deactivate();
        }
    }

    private void ActivateController<T>() where T : UIController
    {
        foreach (var controller in listOfControllers.OfType<T>())
        {
            controller.Activate();
            text.text = "Controller found: " + controller.GetType().Name;

        }
    }

    private void DeactivateController<T>() where T : UIController
    {
        foreach (var controller in listOfControllers.OfType<T>())
        {
            controller.Deactivate();
        }
    }
}