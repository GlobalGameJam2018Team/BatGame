using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatCollision : MonoBehaviour
{
    AudioSource audio;
    public GameObject player;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            audio.Play();
            //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController2>().RatHunted();
            player.GetComponent<PlayerController2>().RatHunted();
            GetComponent<SpriteRenderer>().enabled=false;
            GetComponent<BoxCollider>().enabled = false;
            DestroyObject(this.gameObject, audio.clip.length);
        }
    }
}
