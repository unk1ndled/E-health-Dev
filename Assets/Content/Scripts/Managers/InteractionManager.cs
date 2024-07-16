using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    /*
    private Transform handAnchor;

    [SerializeField]
    private float raycastDistance = 100f;

    private IInteractable currentInteractable;
    private XRInputManager inputManager;

    [SerializeField]
    private float interactCooldown = 0.5f;
    private bool canInteract = true;
    // Start is called before the first frame update

    private void Start()
    {
        inputManager = FindObjectOfType<XRInputManager>();
        handAnchor = GetRightHandAnchor();
    }

    private void Update()
    {
        DetectInteractable();
    }

    private void DetectInteractable()
    {
        if ( handAnchor == null )
        {
            handAnchor = GetRightHandAnchor();
        }

        if ( handAnchor == null || inputManager == null )
        {
            return;
        }
        Ray ray = new Ray(handAnchor.position, handAnchor.forward);
        if ( Physics.Raycast(ray, out RaycastHit hit, raycastDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if ( interactable != null )
            {
                

                //Highlighting the interactable if it's a new interactable 
                if ( interactable != currentInteractable)
                {
                    if ( currentInteractable != null )
                    {
                        currentInteractable.OnUnhighlight();
                    }
                    interactable.OnHighlight();
                    currentInteractable = interactable;
                }

                if ( inputManager.interactInput && canInteract)
                {
                    interactable.OnInteract();
                    //ADDING COROUTINE 
                    StartCoroutine(InteractCooldown());

                }
            }
        }
        else
        {
            if ( currentInteractable != null )
            {
                currentInteractable.OnUnhighlight();
                currentInteractable = null;
            }
        }
    }

    private Transform GetRightHandAnchor()
    {
        OVRCameraRig cameraRig = FindObjectOfType<OVRCameraRig>();
        if ( cameraRig != null )
        {
            return cameraRig.rightHandAnchor;
        }

        Debug.LogWarning("OVRCameraRig not found, Ensure it is present in the scene !");
        return null;
    }

    private IEnumerator InteractCooldown()
    {
        canInteract = false;
        yield return new WaitForSeconds(interactCooldown);
        canInteract = true;
    }
    */
}
