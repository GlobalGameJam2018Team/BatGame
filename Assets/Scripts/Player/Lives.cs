using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {

    public int lives = 3;
    public LayerMask walls;
    public LayerMask enemies;
    public BlackBoard bBoard;
    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 11|| collision.gameObject.layer == 8)
        {
            lives--;
            if (lives < 0)
            {
                GameObject.Find("Canvas").GetComponent<GameUI>().LostGame(collision.gameObject);
            }
            else
            {
                anim.SetBool("dead", true);
                GetComponent<SphereCollider>().enabled=false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                GetComponent<Rigidbody>().useGravity = false ;

            }
        }

    }

    // Update is called once per frame
    void Update () {

       if( anim.GetBool("dead"))
       {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("dead") &&
   anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
                anim.SetBool("dead", false);
                GetComponent<SphereCollider>().enabled = true;
                GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;

                GetComponent<Rigidbody>().useGravity = true;
                Vector3 savePos = bBoard.savePoints[bBoard.lastPointActive].transform.position;
                transform.position = new Vector3(savePos.x, 0, savePos.z);
            }
        }
    }
}
