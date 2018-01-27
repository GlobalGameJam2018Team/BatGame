using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointLogic : MonoBehaviour {

    public int checkPointNumber = 0;
    public bool activated = false;
    SpriteRenderer sprite;
    public Sprite activeCheckPoint;
    public Sprite deactiveCheckPoint;
	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (activated == true)
        {
            sprite.sprite = activeCheckPoint;

        }
        else
        {
            sprite.sprite = deactiveCheckPoint;
        }


	}
}
