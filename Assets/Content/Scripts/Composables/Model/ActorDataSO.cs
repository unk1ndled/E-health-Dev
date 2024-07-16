using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataSO", menuName = "ScriptableObjects/DataSO", order = 1)]
public class ActorDataSO : ScriptableObject
{
    public ActorType actorType;
    public bool canAnimate;
    public List<AnimationClip> animations;
    //Interaction Points
    public List<string> layers;
    public List<string> cuts;
    public string description;
    public string name;
    public List<Shader> shaderTypes;
    public string memo;
    public List<string> legendNames;

    public List<ClinicalSicknesses> clinicalSicknesses;
    public List<ImportantFrame> importantFrames;

}

[System.Serializable]
public class ClinicalSicknesses
{
    public string name;
    public string description;
}

[System.Serializable]
public class ImportantFrame
{
    public int frameNumber;
    public string observation;
}