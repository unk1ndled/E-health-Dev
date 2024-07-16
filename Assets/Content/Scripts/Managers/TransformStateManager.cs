using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformStateManager : MonoBehaviour
{
    private static TransformStateManager instance;
    
    public static TransformStateManager Instance
    {
        get
        {
            if ( instance == null )
            {
                instance = FindObjectOfType<TransformStateManager>();
                if ( instance == null )
                {
                    GameObject managerObj = new GameObject("TransformGameManager");
                    instance = managerObj.AddComponent<TransformStateManager>();
                }
            }
            return instance;
        }
    }

    private UIEditState currentEditState = UIEditState.NONE;

    public void SetTransformState(UIEditState state)
    {
        currentEditState = state;
    }

    public UIEditState GetTransformState()
    {
        return currentEditState;
    }
}
