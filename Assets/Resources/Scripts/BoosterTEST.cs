using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterTEST : ObjectBase, IColoredObject, IScoreChange 
{

    protected override void OnDisable()
    {
        base.OnDisable();
        ChangeScore();
    }

    #region IScoreChange implementation

    public void ChangeScore()
    {
        StaticMembers.PlayerScore += ScoreAmount;
    }

    public void RandomNegative()
    {        
    }  

    public bool Negative { get; set; }

    public float ScoreAmount { get; set; }        

    #endregion

    #region IColoredObject implementation

    public void SetColor()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    #endregion




}
