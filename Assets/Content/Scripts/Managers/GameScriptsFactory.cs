using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScriptsFactory : MonoBehaviour
{
    #region
    public GUIManager guiManager;
    #endregion
    #region Singleton Implementation

    public static GameScriptsFactory Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion
}
