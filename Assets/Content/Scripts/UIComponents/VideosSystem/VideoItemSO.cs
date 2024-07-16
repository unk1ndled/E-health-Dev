using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "VideoItem", menuName = "ScriptableObjects/VideoItem", order = 1)]
public class VideoItemSO : ScriptableObject
{
    [field: SerializeField]
    public string videoName { get; set; }

    [field: SerializeField]
    public VideoClip videoClip { get; set; }

    public int ID => GetInstanceID();
}
