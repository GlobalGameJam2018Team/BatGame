using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCollission : MonoBehaviour {


    public BlackBoard bBoard;
	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == 12)
        {
            CheckPointLogic check = collision.gameObject.GetComponent<CheckPointLogic>();
            if(!check.activated)
            {
                if (check.checkPointNumber > bBoard.lastPointActive)
                    bBoard.lastPointActive = check.checkPointNumber;

                check.activated = false;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
