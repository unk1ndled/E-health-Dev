using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHoverable
{
    bool IsHovering { get; }
    string GetHoverText();
}
