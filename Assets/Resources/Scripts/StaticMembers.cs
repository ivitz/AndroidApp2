using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticMembers 
{    
    public static bool IsPaused { get; set; }
   
    public static bool IsGameOver { get; set; }

    //I decided to make player score a static member so everyone can access it
    public static float PlayerScore { get; set; }

    /// <summary>
    /// Resets the static variables (score to 0, all bools to false). Call this on game restart or scene change if needed.
    /// </summary>
    public static void ResetStaticVariables ()
    {
        IsPaused = false;
        IsGameOver = false;
        PlayerScore = 0;
    }
}
