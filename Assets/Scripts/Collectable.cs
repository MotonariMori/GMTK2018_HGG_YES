using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public int iPlayerScore;
    //public GameObject playerScoreUI;

    void Start()
    {
        
    }

    void Update ()
    {
        //playerScoreUI.gameObject.GetComponent<Text>().text = ("Garbage collected: " + iPlayerScore);
        //Debug.Log("Eingesammelt: " + iPlayerScore);
	}

    int CountScore()
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
