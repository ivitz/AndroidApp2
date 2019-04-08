using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainShapedObject : ObjectBase, IScoreChange, IColoredObject, ISpriteSelection {

    [Tooltip("How much score will be taken from player if this object is disabled on itself")]
    public float reduceScoreOnDisable;

    [SerializeField]
    private bool _negative;
    public bool Negative 
    { 
        get {return _negative;} 
        set { _negative = value;} 
    }
   
    //The amount of score that this object will give or take
    [SerializeField]
    private float _scoreAmount;
    public float ScoreAmount 
    { 
        get { return _scoreAmount; } 
        set { _scoreAmount = value; } 
    }

    [SerializeField]
    private Sprite[] _spriteVariations;
    public Sprite[] SpriteVariations 
    { 
        get {return _spriteVariations; } 
        set {_spriteVariations = value; }
    }

    private SpriteRenderer spriteRenderer;

    private void Update()
    {
        if (!StaticMembers.IsPaused && !StaticMembers.IsGameOver)
        {
            DisableInTime();
        }
    }

    //Overriding OnEnable because we need a different functionality for this type of object. But also use base method
    protected override void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        base.OnEnable();
        RandomNegative();
        CalculateAliveTime();
        SelectRandomSprite();
        SetColor();
    }

    protected override void CalculateAliveTime()
    {
        int rnd = Random.Range(7, 25);

        //Calculate the time when the object has to be disabled
        if (Negative)
        {
            disableTime = Time.time + (aliveTime * rnd);
        } 
        else
            disableTime = Time.time + aliveTime;
    }

    protected override void DisableInTime()
    {
        if (Time.time >= disableTime)
        {
            if (!Negative)
            {
                StaticMembers.PlayerScore -= reduceScoreOnDisable;
            }
            gameObject.SetActive(false);
        }
    }

    public override void IsTapped()
    {        
        gameObject.SetActive(false);
        ChangeScore();
    }

    public void RandomNegative()
    {
        int rnd = Random.Range(0, 2);
        if (rnd == 0)
        {
            Negative = false;
        }
           
        if (rnd == 1)
        {
            Negative = true;  
        }            
    }

    /// <summary>Color the object red if it is a negative object (will substract the earned score). Color the object green if it is a positive object</summary>
    public void SetColor()
    {
        if (Negative)
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.green;
        }
    }

    /// <summary>Changes the score. If negative - reduce the score (x5 more than add). If positive - add score</summary>
    public void ChangeScore()    
    {
        if (Negative)
        {
            StaticMembers.PlayerScore -= ScoreAmount * 5;
        }
        else
        {
            StaticMembers.PlayerScore += ScoreAmount;
        }
    }

    /// <summary>Selects the random sprite for an object (for now it is sphere or box shapes)</summary>
    public void SelectRandomSprite()
    {
        int rnd = Random.Range(0, SpriteVariations.Length);

        spriteRenderer.sprite = SpriteVariations[rnd];
    }
}
