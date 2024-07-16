using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "OptionDataSO", menuName = "ScriptableObjects/OptionDataSO", order = 1)]
public class OptionDataSO : ScriptableObject
{
    public List<OptionData> optionDataList;
}

[System.Serializable]
public class OptionData
{
    public string optionName;
    public List<string> items;
}