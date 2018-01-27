using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {

    Rigidbody phys;

    public float horizontal_speed = 3.0f;
    public float force = 500;

    //Slowing Debuff
    private bool slow_debuff = false;
    private float slow_timer = 0.0f;
    private float decrease_amount = 1.0f;

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
       /*
        float angle = Mathf.Atan2(phys.velocity.x, phys.velocity.y / 2.0f) * Mathf.Rad2Deg - 90;
        gameObject.transform.eulerAngles = new Vector3(0, 0, -angle);
        */

        if (Input.GetKeyDown("space"))
        {
            phys.velocity = new Vector3(phys.velocity.x, 0, phys.velocity.z);
            phys.AddForce(new Vector3(0, 0, force));            
        }
     
        if (Input.GetKey(KeyCode.RightArrow))
        {
            phys.velocity = new Vector3(horizontal_speed, 0, phys.velocity.z);
        }
       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            phys.velocity = new Vector3(-horizontal_speed, 0, phys.velocity.z);
        }
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        //Slowing debuff
        if (slow_debuff)
        {
            if (slow_timer <= 0.0f)
            {
                force *= decrease_amount;
                horizontal_speed *= decrease_amount;
                slow_debuff = false;
            }
            slow_timer -= Time.deltaTime;
        }
        //--------------
    }

    public void SlowDebuff(float decrease, float time)
    {
        if (!slow_debuff)
        {
            force /= decrease;
            horizontal_speed /= decrease;
            decrease_amount = decrease;
        }
        slow_timer = time;
        slow_debuff = true;
    }
}
