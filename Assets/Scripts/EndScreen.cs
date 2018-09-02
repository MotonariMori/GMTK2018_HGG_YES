using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {

    public GameObject LosingScreen;
    public GameObject WinningScreen;
    private bool bLostGame = false;

    // Update is called once per frame

    void Update () {
        if (bLostGame)
        {
            LoadLostScreen();
        } else
        {
            LoadWinScreen();
        }

	}

    public void LoadLostScreen()
    {
        LosingScreen.SetActive(true);
        WinningScreen.SetActive(false);
    }

    public void LoadWinScreen()
    {
        WinningScreen.SetActive(true);
        LosingScreen.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(3);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
