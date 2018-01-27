using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {

    public int lives = 3;
    public LayerMask walls;
    public LayerMask enemies;
    public BlackBoard bBoard;
// Use this for initialization
	void Start () {
     
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 10 || collision.gameObject.layer ==11)
        {
            lives--;
            if (!bBoard.savePointActive)
                transform.position = new Vector3(bBoard.initialPos.x, 0, bBoard.initialPos.y);
            else
                transform.position = new Vector3(bBoard.savePointPos.x, 0, bBoard.savePointPos.y);
            
        }

    }

    // Update is called once per frame
    void Update () {
      

	}
}
