using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [Header("--Include all object poolers here--")]
    public ObjectPooler MainObjectPooler;

    [Header("--Stats--")]
    [Tooltip("The less the number, the faster the objects will spawn")]
    public float ObjectSpawnRate;

    public static GameManager Instance { get; set;}

    [Tooltip("This is how much time player has to gain score before GameOver")]
    public float timeLeft;

    private bool pause;

    private InterfaceManager interfaceManager;


	void Start () 
    {
        //Get the interface manager that is attached to this gameobject.
        interfaceManager = GetComponent<InterfaceManager>();

        //Make one instance of GameManager.
        if (Instance == null)
        {
            Instance = this;
        }

        InvokeRepeating("PoolObjects", 1, ObjectSpawnRate);
	}	

    //Calculate time here and call GameOver if timer reaches 0
	void Update () 
    {
        if (!StaticMembers.IsGameOver)
        {
            if (timeLeft <= 0)
            {
                GameOver();
            }
            //calculate the time left
            timeLeft -= Time.deltaTime;
        }
	}

    /// <summary>
    /// Call this when the timer reaches 0. Cancel all invokes and enable game over interface.
    /// </summary>
    void GameOver()
    {
        CancelInvoke();
        StaticMembers.IsGameOver = true;
        interfaceManager.gameOverPanel.SetActive(true);
        interfaceManager.gameOverScoreText.text = "You Score: " + StaticMembers.PlayerScore;
    }

    public void RestartTheGame()
    {
        timeLeft = 60;
        interfaceManager.gameOverPanel.SetActive(false);
        StaticMembers.ResetStaticVariables();
        InvokeRepeating("PoolObjects", 1, ObjectSpawnRate);
        foreach (GameObject obj in MainObjectPooler.objectList)
        {
            obj.SetActive(false);
        }
    }

    void PoolObjects()
    {
        //Get the available road block from the pool, enable it and place correctly
        GameObject obj = MainObjectPooler.GetObject();       
        obj.SetActive(true);
    }
}
