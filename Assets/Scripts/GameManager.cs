﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    private int iFrameCounter;
    private int iAirInSeconds;

    public PlayerController myPlayer;
    public Text playerScoreUI;
    public int iPlayerScore;

    // Use this for initialization
    void Start () {

        myPlayer = FindObjectOfType<PlayerController>();
        iFrameCounter = 0;
        iAirInSeconds = 6;
        iPlayerScore = 0;
        
	}
	
	// Update is called once per frame
	void Update () {
		
        if (!myPlayer.bInWater)
        {
            iFrameCounter++;
            if (iFrameCounter % 60 == 0)
            {
                if (iAirInSeconds > 0)
                {
                    iAirInSeconds--;
                }
                else
                {
                    myPlayer.iHealth--;
                    iAirInSeconds = 6;
                }
                //print(iAirInSeconds);
            }
        }
        else
        {
            iFrameCounter = 0;
            myPlayer.iHealth = 3;
            iAirInSeconds = 6;
           // print(iAirInSeconds);
        }

        if (myPlayer.iHealth <= 0)
        {
            //print("You Suck!");
            SceneManager.LoadScene(2);
        }
         //Count Garbage
        playerScoreUI.text = ("" + iPlayerScore);
    }

    public int CountScore()
    {
        iPlayerScore = iPlayerScore + 1;
        return iPlayerScore;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CountScore();
        Destroy(gameObject);
    }

}
