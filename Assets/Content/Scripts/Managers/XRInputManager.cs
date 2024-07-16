using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRInputManager : MonoBehaviour
{   /*
    private EditMode editMode;
    public float rotationInputX { get; private set; }
    public float rotationInputY { get; private set; }

    public float scaleInputUp { get; private set; }

    public float scaleInputDown { get; private set; }

    public float translateInputX { get; private set; }
    public float translateInputZ { get; private set; }

    public bool interactInput { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        editMode = EditMode.TRANSLATE;
    }

    // Update is called once per frame
    private void Update()
    {
        switch (editMode) {
            case (EditMode.ROTATE):
                rotationInputX = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
                rotationInputY = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;
                break;
            case (EditMode.SCALE):
                scaleInputUp = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
                scaleInputDown = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
                return;
            case (EditMode.TRANSLATE):
                translateInputX = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
                translateInputZ = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;
                break;
            default:
                break;
        }

        interactInput = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger);
    }
    */
}
