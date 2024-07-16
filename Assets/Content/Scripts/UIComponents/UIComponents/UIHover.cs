using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHover : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI hoverText;
    
    public void SetText(string text)
    {
        if (hoverText != null )
        {
            hoverText.text = text;
        }
    }
}
