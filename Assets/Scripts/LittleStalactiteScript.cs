using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleStalactiteScript : MonoBehaviour {


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<Lives>().lives--;

            BlackBoard bb = GameObject.FindGameObjectWithTag("BlackBoard").GetComponent<BlackBoard>();
            Vector3 pos = bb.savePoints[bb.lastPointActive].transform.position;
            collision.gameObject.transform.position = new Vector3(pos.x, 0, pos.z);
        }
    }
}
