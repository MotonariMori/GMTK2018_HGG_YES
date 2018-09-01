using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private int iFrameCounter;
    private int iAirInSeconds;

    public NickController myPlayer;

	// Use this for initialization
	void Start () {

        myPlayer = FindObjectOfType<NickController>();
        iFrameCounter = 0;
        iAirInSeconds = 6;

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

	}
}
