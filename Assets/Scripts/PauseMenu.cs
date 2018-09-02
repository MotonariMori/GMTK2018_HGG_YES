using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public bool bGameIsPaused = false;

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

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        bGameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        bGameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
