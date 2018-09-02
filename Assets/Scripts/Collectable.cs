using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    private GameManager myGM;

    private SpriteRenderer mySpriteRenderer;
    public Sprite Sprite01;
    public Sprite Sprite02;
    public Sprite Sprite03;
    public Sprite Sprite04;

    private int SpriteDecider;

    private void Start()
    {
        myGM = FindObjectOfType<GameManager>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        SpriteDecider = Random.Range(1, 5);

        switch (SpriteDecider)
        {
            case 1:
                mySpriteRenderer.sprite = Sprite01;
                break;
            case 2:
                mySpriteRenderer.sprite = Sprite02;
                break;
            case 3:
                mySpriteRenderer.sprite = Sprite03;
                break;
            default:
                mySpriteRenderer.sprite = Sprite04;
                break;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        myGM.CountScore();
        Destroy(gameObject);
    }

}
