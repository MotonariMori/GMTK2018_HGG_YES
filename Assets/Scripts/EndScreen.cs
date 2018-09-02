﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour {

    public bool bLostGame;
    public GameObject LosingScreen;
    public GameObject WinningScreen; 

	// Update is called once per frame
	void Update () {
        if (!bLostGame)
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
}