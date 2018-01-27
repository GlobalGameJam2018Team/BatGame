using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagmiteCollision : MonoBehaviour {

    GameObject player;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Fall();

            collision.gameObject.GetComponent<Lives>().lives--;
            
            BlackBoard bb = GameObject.FindGameObjectWithTag("BlackBoard").GetComponent<BlackBoard>();
            Vector3 pos = bb.savePoints[bb.lastPointActive].transform.position;
            collision.gameObject.transform.position = new Vector3(pos.x, 0, pos.z);
        }
    }

    public void Fall()
    {
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY;
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().isKinematic = false;
    }
}
