using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Todo : MonoBehaviour
{
    private bool isAttached = false;
    private Vector3 originalPosition;
    private Transform originalParent;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
        originalParent = transform.parent;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isAttached)
            return;

        // Check if the other collider is an attachment point and if it is not occupied
        if (collision.collider.CompareTag("AttachmentPoint"))
        {
            AttachmentPoint attachmentPoint = collision.collider.GetComponent<AttachmentPoint>();
            if (attachmentPoint != null && !attachmentPoint.IsOccupied)
            {
                Debug.Log("attached");
                AttachToPoint(attachmentPoint);
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Check if we are detaching from the current attachment point
        if (collision.collider.CompareTag("AttachmentPoint") && isAttached)
        {
            AttachmentPoint attachmentPoint = collision.collider.GetComponent<AttachmentPoint>();
            if (attachmentPoint != null && attachmentPoint.IsOccupied)
            {
                Debug.Log("detached");
                DetachFromPoint(attachmentPoint);
            }
        }
    }

    void AttachToPoint(AttachmentPoint point)
    {
        // Attach to the point
        transform.SetParent(point.transform);
        originalPosition = transform.position;

        transform.position = point.transform.position;

        point.IsOccupied = true;
        isAttached = true;

        // Disable physics to prevent further movement
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.mass = 0;
        }
    }

    void DetachFromPoint(AttachmentPoint point)
    {
        // Detach from the point
        point.IsOccupied = false;
        isAttached = false;

        // Reset the original state
        transform.position = originalPosition;
        transform.SetParent(originalParent);

        // Enable physics again
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.mass = 1; // Set back to the original mass value
        }
    }
}
