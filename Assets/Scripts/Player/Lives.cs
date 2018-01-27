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
            transform.position = new Vector3(bBoard.savePoints[bBoard.lastPointActive].x, 0, bBoard.savePoints[bBoard.lastPointActive].y);
          
        }

    }

    // Update is called once per frame
    void Update () {
      

	}
}
