using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum STALACTITE_STATE
{
    IDLE_ST,
    READY_TO_FALL_ST,
    FALLING_ST,
    READY_TO_RESET_ST
}


public class StalagmiteCollision : MonoBehaviour {

    GameObject player;
    STALACTITE_STATE state = STALACTITE_STATE.IDLE_ST;
    bool hited = false;
    public bool down_estalagmite = false;
    
    public GameObject stalagmite_a;
    Vector3 stalagmite_a_init_pos;
    Quaternion stalagmite_a_init_rot;

    public GameObject stalagmite_b;
    Vector3 stalagmite_b_init_pos;
    Quaternion stalagmite_b_init_rot;

    public GameObject stalagmite_c;
    Vector3 stalagmite_c_init_pos;
    Quaternion stalagmite_c_init_rot;

    public float fall_delay = 0.5f;
    float cur_delay = 0.0f;



    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stalagmite_a_init_pos = stalagmite_a.transform.position;
        stalagmite_a_init_rot = stalagmite_a.transform.rotation;
        stalagmite_b_init_pos = stalagmite_b.transform.position;
        stalagmite_b_init_rot = stalagmite_b.transform.rotation;
        stalagmite_c_init_pos = stalagmite_c.transform.position;
        stalagmite_c_init_rot = stalagmite_c.transform.rotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (state == STALACTITE_STATE.READY_TO_FALL_ST)
        {
            cur_delay += Time.deltaTime;
            if (cur_delay >= fall_delay)
            {
                state = STALACTITE_STATE.FALLING_ST;
                cur_delay = 0.0f;
                Fall();
            }
        }
        else if (state == STALACTITE_STATE.FALLING_ST)
        {

            float val = Mathf.Abs(Vector3.Magnitude(player.transform.position - this.transform.position));

            if (val >= 35)
            {
                stalagmite_a.SetActive(false);
                stalagmite_a.transform.position = stalagmite_a_init_pos;
                stalagmite_a.transform.rotation = stalagmite_a_init_rot;

                stalagmite_b.SetActive(false);
                stalagmite_b.transform.position = stalagmite_b_init_pos;
                stalagmite_b.transform.rotation = stalagmite_b_init_rot;

                stalagmite_c.SetActive(false);
                stalagmite_c.transform.position = stalagmite_c_init_pos;
                stalagmite_c.transform.rotation = stalagmite_c_init_rot;

                this.GetComponent<SpriteRenderer>().enabled = true;
                this.GetComponent<BoxCollider>().enabled = true;

                hited = false;
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            if (!down_estalagmite)
            {
                hited = true;
                StartFall();
            }
        }
    }

    public void StartFall()
    {
        float val = Mathf.Abs(Vector3.Magnitude(player.transform.position - this.transform.position));

        if (val <= 20)
        {
            if (!down_estalagmite)
            {
                if (hited) state = STALACTITE_STATE.READY_TO_FALL_ST;
                else hited = true;
            }
        }
    }

    public void Fall()
    {
        //Disable the main cube and instance the three childs
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;

        stalagmite_a.SetActive(true);
        stalagmite_a.GetComponent<Rigidbody>().isKinematic = true;
        stalagmite_a.GetComponent<Rigidbody>().isKinematic = false;
        stalagmite_b.SetActive(true);
        stalagmite_b.GetComponent<Rigidbody>().isKinematic = true;
        stalagmite_b.GetComponent<Rigidbody>().isKinematic = false;
        stalagmite_c.SetActive(true);
        stalagmite_c.GetComponent<Rigidbody>().isKinematic = true;
        stalagmite_c.GetComponent<Rigidbody>().isKinematic = false;


        /*this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY;
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().isKinematic = false;*/

        state = STALACTITE_STATE.FALLING_ST;
    }
}
