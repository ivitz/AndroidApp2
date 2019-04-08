using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use this interface if the object will have a different color depending on its role (green for positive, red for negative
/// </summary>
public interface IColoredObject 
{
    void SetColor();
}
