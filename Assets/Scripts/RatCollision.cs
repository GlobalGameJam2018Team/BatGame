using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController2>().RatHunted();
            DestroyObject(this.gameObject);
        }
    }
}
