using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LivesGUI : MonoBehaviour {

    public Sprite threeLives;
    public Sprite twoLives;
    public Sprite oneLife;
    public Sprite zeroLives;

    public GameObject player;

    Image img;
    Lives livesScript;
    int actualLives = 0;
    // Use this for initialization
    void Start () {
        img = GetComponent<Image>();
        livesScript = player.GetComponent<Lives>();
        actualLives = livesScript.lives;

    }
	
	// Update is called once per frame
	void Update () {
        actualLives = livesScript.lives;

        if (actualLives == 3)
        {
            img.sprite = threeLives;
        }
        else if(actualLives == 2)
        {
            img.sprite = twoLives;
        }

        else if(actualLives == 1)
        {
            img.sprite = oneLife;
        }
        else if(actualLives == 0)
        {
            img.sprite = zeroLives;
        }
	}
}
