using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {

    Rigidbody phys;

    public float velocity = 0.1f;
    public int force = 500;
    
	// Use this for initialization
	void Start ()
    {
        Physics.gravity = new Vector3(0, 0, -9.81f);
        phys = GetComponent<Rigidbody>();
        phys.velocity = new Vector3(1, 0, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
       /* float angle = Mathf.Atan2(phys.velocity.x, phys.velocity.y / 2.0f) * Mathf.Rad2Deg - 90;
        gameObject.transform.eulerAngles = new Vector3(0, 0, -angle);

*/
        if (Input.GetKeyDown("space"))
        {
            phys.velocity = new Vector3(phys.velocity.x, 0, phys.velocity.z);
            phys.AddForce(new Vector3(0, 0, force));
            
        }

     
        if (Input.GetKey(KeyCode.RightArrow))
        {
            phys.velocity = new Vector3(3, phys.velocity.y, phys.velocity.z);
        }
       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            phys.velocity = new Vector3(-3, phys.velocity.y, phys.velocity.z);
        }

    }
}
