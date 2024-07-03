using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    // Attached game object for enabling/disabling
    public GameObject Environment;

    // Method to enable or disable the environment and its children
    public void SetEnvironmentActive(bool isActive)
    {
        // Set the active state of the Environment GameObject
        Environment.SetActive(isActive);

        // Get all children of the Environment GameObject
        foreach (Transform child in Environment.transform)
        {
            // Set the active state of each child GameObject
            child.gameObject.SetActive(isActive);
        }
    }
}
