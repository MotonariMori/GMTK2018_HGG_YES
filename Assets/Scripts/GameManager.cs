using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    private int iFrameCounter;
    [SerializeField]
    private int iAirInSeconds;

    private int iFramesInWater;

    public PlayerController myPlayer;
    public Text playerScoreUI;
    public int iPlayerScore;

    [Space(10)]
    [Header("Health")]
    public Image HealthUI;
    public Sprite SpriteEmpty;
    public Sprite SpriteOne;
    public Sprite SpriteTwo;
    public Sprite SpriteFull;
    [Space (10)]
    [Header("Air")]
    public Image Air1;
    public Image Air2;
    public Image Air3;

    public PauseMenu myPauseMenu;
    public EndScreen myEndScreen;

    // Use this for initialization
    void Start () {

        myPauseMenu = FindObjectOfType<PauseMenu>();
        myEndScreen = FindObjectOfType<EndScreen>();
        myPlayer = FindObjectOfType<PlayerController>();
        iFrameCounter = 0;
        iAirInSeconds = 18;
        iPlayerScore = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if (iAirInSeconds < 12)
            Air3.enabled = false;
        else
            Air3.enabled = true;

        if (iAirInSeconds < 6)
            Air2.enabled = false;
        else
            Air2.enabled = true;

        if (iAirInSeconds < 1)
            Air1.enabled = false;
        else
            Air1.enabled = true;

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

        if (!myPauseMenu.bGameIsPaused)
        {
            if (!myPlayer.bInWater)
            {
                iFrameCounter++;
                if (iFrameCounter % 60 == 0)
                {
                    if (iAirInSeconds % 6 == 0 && iAirInSeconds < 18)
                    {
                        myPlayer.iHealth--;
                        iAirInSeconds--;

                    }
                    else
                    {

                        iAirInSeconds--;
                    }
                    
                }
            }
            else
            {
                iFrameCounter = 0;

                if (myPlayer.iHealth < 3)
                {
                    iFramesInWater++;

                    if (iFramesInWater % 120 == 0)
                    {
                        myPlayer.iHealth++;
                    }
                    
                }
                else
                    iFramesInWater = 0;

                if (iAirInSeconds < 18)
                    if (iFramesInWater % 20 == 0)
                        iAirInSeconds++;
            }

            if (myPlayer.iHealth <= 0)
            {
                //print("You Suck!");
                SceneManager.LoadScene(4);
                myEndScreen.bLostGame = false;
            }
            //Count Garbage
            playerScoreUI.text = ("" + iPlayerScore);
        }
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
