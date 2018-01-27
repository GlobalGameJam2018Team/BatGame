using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagmiteCollision : MonoBehaviour {

    GameObject player;

    public GameObject stalagmite_a;
    Vector3 stalagmite_a_init_pos;
    public GameObject stalagmite_b;
    Vector3 stalagmite_b_init_pos;
    public GameObject stalagmite_c;
    Vector3 stalagmite_c_init_pos;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stalagmite_a_init_pos = stalagmite_a.transform.position;
        stalagmite_b_init_pos = stalagmite_b.transform.position;
        stalagmite_c_init_pos = stalagmite_c.transform.position;
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
        //Disable the main cube and instance the three childs
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;

        stalagmite_a.SetActive(true);
        stalagmite_a.GetComponent<Rigidbody>().WakeUp();
        stalagmite_b.SetActive(true);
        stalagmite_b.GetComponent<Rigidbody>().WakeUp();
        stalagmite_c.SetActive(true);
        stalagmite_c.GetComponent<Rigidbody>().WakeUp();

        /*this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY;
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().isKinematic = false;*/
    }
}
