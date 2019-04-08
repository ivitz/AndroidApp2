using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour {

    public Text scoreText;

    public Text timer;

    public GameObject gameOverPanel;

    public Text gameOverScoreText;

    private bool pause;	

	void Update () 
    {
        timer.text = "Time Left: " + Mathf.Floor(GameManager.Instance.timeLeft); 
        scoreText.text = "Score: " + Mathf.Floor(StaticMembers.PlayerScore);	
	}

    /// <summary>
    /// Pause the game (Timescale to 0) and unpause (timescale to 1)
    /// </summary>
    public void Pause()
    {
        pause = !pause;

        if (pause)
        {
            Time.timeScale = 0;
        }

        if (!pause)
        {
            Time.timeScale = 1;
        }
    }
}
