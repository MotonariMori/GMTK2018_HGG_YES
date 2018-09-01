using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    private GameManager myGM;

    private void Start()
    {
        myGM = FindObjectOfType<GameManager>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        myGM.CountScore();
        Destroy(gameObject);
    }

}
