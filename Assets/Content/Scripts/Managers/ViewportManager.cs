using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewportManager : MonoBehaviour
{

    private GameObject actor;

    [SerializeField]
    private GameObject[] viewports;

    private GameObject[] actorCopies;


    // Start is called before the first frame update
    private void Start()
    {
        actorCopies = new GameObject[viewports.Length];
    }

    public void RotateActor(Vector3 axis, float angle )
    {
        if (actor != null)
        {
            actor.transform.Rotate(axis, angle);
        }
    }

    public void ShowInViewports()
    {
        if (actor != null)
        {
            HideActor();
            DuplicateAndPositionActors();
        }
    }

    public void HideInViewports()
    {
        if ( actor != null )
        {
            ShowActor();
            ClearViewports();
        }
    }

    private void HideActor()
    {
        actor.gameObject.SetActive(false);
    }

    private void ShowActor()
    {
        actor.gameObject.SetActive(true);
    }

    private void ClearViewports()
    {
        for ( int i = 0; i < viewports.Length; i++ )
        {
            if ( actorCopies[i] != null )
            {
                Destroy(actorCopies[i]);
                actorCopies[i] = null;
            }
        }
    }

    public void RotateActorInViewports(Vector3 axis, float angle) 
    {
        for ( int i = 0; i < viewports.Length; i++ )
        {
            if ( actorCopies[i] != null )
            {
                actorCopies[i].transform.Rotate(axis, angle);
            }
        }
    }

    private void DuplicateAndPositionActors()
    {
        Vector3[] positions = { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };
        
        for ( int i = 0; i < viewports.Length; i++ )
        {
            if ( actorCopies[i] != null )
            {
                Destroy(actorCopies[i]);
            }

            actorCopies[i] = Instantiate(actor, viewports[i].transform);
            actorCopies[i].transform.localPosition = Vector3.zero;
            actorCopies[i].transform.localRotation = Quaternion.identity;
            actorCopies[i].SetActive(true);
            actorCopies[i].transform.position += positions[i % positions.Length];

        }

    }
}
