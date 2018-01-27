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
                GameObject.Find("Canvas").GetComponent<WinLoseUI>().LostGame(collision.gameObject);
            }
            else
            {
                anim.SetBool("dead", true);
                
          
            }
        }

    }

    // Update is called once per frame
    void Update () {

       if( anim.GetBool("dead"))
       {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("dead"))
        {
                anim.SetBool("dead", false);

                Vector3 savePos = bBoard.savePoints[bBoard.lastPointActive].transform.position;
                transform.position = new Vector3(savePos.x, 0, savePos.z);
            }
        }
    }
}
