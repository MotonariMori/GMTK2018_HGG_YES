using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public float iPlayerScore = 0f;
    public GameObject playerScoreUI; 
	
	
	void Update ()
    {
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Garbage collected: " + iPlayerScore);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            CountScore();
            Destroy(gameObject);
        }
    }

    float CountScore()
    {
        iPlayerScore = iPlayerScore + 1;
        return iPlayerScore;
    }

}
