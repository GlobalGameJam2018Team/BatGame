using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatCollision : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            player.GetComponent<PlayerController2>().RatHunted();
            DestroyObject(this.gameObject);
        }
    }
}
