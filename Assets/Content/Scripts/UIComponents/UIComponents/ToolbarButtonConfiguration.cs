using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ToolbarButtonConfiguration", menuName = "UI/ToolbarButtonConfiguration", order = 1)]
public class ToolbarButtonConfiguration : ScriptableObject
{

    public string configurationKey;
    public List<string> buttonNames;

    public List<string> popupButtonNames;
}
