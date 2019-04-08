using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use this interface if the object needs a different random sprites selected
/// </summary>
public interface ISpriteSelection
{
    Sprite[] SpriteVariations { get; set;}

    /// <summary>
    /// Selects the random sprite for an object (for now it is sphere or box shapes).
    /// </summary>
    void SelectRandomSprite();
}
