using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {

    public int lives = 3;
    public LayerMask walls;
    public LayerMask enemies;
    public BlackBoard bBoard;
    Animator anim;
    bool can_die = true;
    public AudioSource fly;

    public AudioSource hit;
    void Start ()
    {
        anim = GetComponent<Animator>();
        can_die = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.layer == 10 || collision.gameObject.layer == 11 || collision.gameObject.layer == 14) && can_die)
        {
            can_die = false;
            lives--;
            if (lives < 0)
            {
                GameObject.Find("Canvas").GetComponent<GameUI>().LostGame(collision.gameObject);
            }
            else
            {
                fly.Stop();
                hit.Play();
                anim.SetBool("dead", true);
                GetComponent<SphereCollider>().enabled=false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                GetComponent<Rigidbody>().useGravity = false;
            }
        }
        if(collision.gameObject.layer == 15)
        {
            GetComponent<SphereCollider>().enabled = false;

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            GetComponent<Rigidbody>().useGravity = false;
            GameObject.Find("Canvas").GetComponent<GameUI>().WinGame(GetComponent<PlayerController2>().GetRatsHunted());
        }

    }

    void Update () {

       if( anim.GetBool("dead"))
       {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("dead") &&
   anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
                fly.Play();
                anim.SetBool("dead", false);
                GetComponent<SphereCollider>().enabled = true;
                GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;

                GetComponent<Rigidbody>().useGravity = true;
                Vector3 savePos = bBoard.savePoints[bBoard.lastPointActive].transform.position;
                transform.position = new Vector3(savePos.x, 0, savePos.z);
                can_die = true;
            }
        }
    }
}
