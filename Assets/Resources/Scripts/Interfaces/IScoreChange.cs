using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use this interface if the object will influence the player's score
/// </summary>
public interface IScoreChange 
{
        
    bool Negative { get; set; }

    //The amount of score that will be given or taken from the player
    float ScoreAmount { get; set;}

    /// <summary>
    /// Changes the score. Give score if positive object, remove score if negative
    /// </summary>
    void ChangeScore();

    /// <summary>
    /// Randomly makes the object negative or positive
    /// </summary>
    void RandomNegative();
}
