using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public static bool bGameIsPaused = false;

    public GameObject pauseMenuUI;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Pause"))
        {
            if (bGameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
	}

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        bGameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        bGameIsPaused = true;
    }
}
