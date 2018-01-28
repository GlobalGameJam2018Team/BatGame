using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {

    Rigidbody phys;
        Animator anim;

    public SpriteRenderer renderer;
    public float horizontal_speed = 3.0f;
    public float force = 500;

    //Slowing Debuff
    private bool slow_debuff = false;
    private float slow_timer = 0.0f;
    private float decrease_amount = 1.0f;

    private int rats_hunted = 0;

    // Use this for initialization
    void Start ()
    {
                anim = GetComponent<Animator>();

        Physics.gravity = new Vector3(0, 0, -9.81f);
        phys = GetComponent<Rigidbody>();
        phys.velocity = new Vector3(1, 0, 0);
        rats_hunted = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
       /*
        float angle = Mathf.Atan2(phys.velocity.x, phys.velocity.y / 2.0f) * Mathf.Rad2Deg - 90;
        gameObject.transform.eulerAngles = new Vector3(0, 0, -angle);
        */

        if (Input.GetKey(KeyCode.UpArrow) && !anim.GetBool("dead"))
        {
            phys.velocity = new Vector3(phys.velocity.x, phys.velocity.y, 0);
            phys.AddForce(new Vector3(0, 0, force));            
        }

        if (Input.GetKey(KeyCode.RightArrow) && !anim.GetBool("dead"))
        {
            phys.velocity = new Vector3(horizontal_speed, 0, phys.velocity.z);
            renderer.flipX = false;

        }
       
        if (Input.GetKey(KeyCode.LeftArrow)&&!anim.GetBool("dead"))
        {
            phys.velocity = new Vector3(-horizontal_speed, 0, phys.velocity.z);
            renderer.flipX = true;


        }
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

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

    public void RatHunted()
    {
        rats_hunted++;
    }

    public int GetRatsHunted()
    {
        return rats_hunted;
    }
}
