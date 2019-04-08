using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The base for each object. Implements OnEnable and OnDisable methods. Also has a CalculatePosition method to calculate where the object need to be placed
/// </summary>
public class ObjectBase : MonoBehaviour
{
    [Tooltip("Set to true if you want this object to be disable after some time")]
    public bool disableInTime;

    [Tooltip("Set the time the object will be enabled")]
    [Range(0.5f, 10f)]
    public float aliveTime;

    /// <summary>The time when this object has to be disabled</summary>
    protected float disableTime; 


    /// <summary>Use this if you want to disable the object after some time</summary>
    protected virtual void DisableInTime()
    {
        return;
    }

    /// <summary>Calculates the time the object will be enabled</summary>
    protected virtual void CalculateAliveTime()
    {      
        return;
    }

    /// <summary>
    /// Determines whether this object was tapped. You need to put a tap logic here and play the animation. When the animation is over - disable the object and call OnDisable().
    /// Also you may add a logic for different type of objects (like boosts, timer bonus etc)
    /// </summary>
    public virtual void IsTapped()
    {  
        gameObject.SetActive(false);
    }

    /// <summary>After the object is pooled from the pool - calculate the position where it will be placed again OnEnable()</summary>
    protected virtual void OnEnable()
    {        
        CalculatePosition();
    }

    protected virtual void OnDisable()
    {    
        return;
    }

    /// <summary>Calculates the position where the object will be instantiated</summary>   
    protected virtual void CalculatePosition()
    {
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.95f, 0)).x);
        float spawnY = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height * 0.8f)).y);

        transform.position = new Vector2(spawnX, spawnY);
    }
}
