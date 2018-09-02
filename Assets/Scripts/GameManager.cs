using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    private int iFrameCounter;
    private int iAirInSeconds;

    private int iFramesInWater;

    public PlayerController myPlayer;
    public Text playerScoreUI;
    public int iPlayerScore;
    public Image HealthUI;

    public Sprite SpriteEmpty;
    public Sprite SpriteOne;
    public Sprite SpriteTwo;
    public Sprite SpriteFull;

    public PauseMenu myPauseMenu;

    // Use this for initialization
    void Start () {

        myPauseMenu = FindObjectOfType<PauseMenu>();
        myPlayer = FindObjectOfType<PlayerController>();
        iFrameCounter = 0;
        iAirInSeconds = 6;
        iPlayerScore = 0;
        
	}
	
	// Update is called once per frame
	void Update () {

        if (!myPauseMenu.bGameIsPaused)
        {
            switch (myPlayer.iHealth)
            {
                case 0:
                    HealthUI.sprite = SpriteEmpty;
                    break;
                case 1:
                    HealthUI.sprite = SpriteOne;
                    break;
                case 2:
                    HealthUI.sprite = SpriteTwo;
                    break;
                default:
                    HealthUI.sprite = SpriteFull;
                    break;
            }
        }
		
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

            if (myPlayer.iHealth < 3)
            {
                if (iFramesInWater % 120 == 0)
                {
                    myPlayer.iHealth++;
                }

                iFramesInWater++;
            }
            else
                iFramesInWater = 0;

            iAirInSeconds = 6;
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
