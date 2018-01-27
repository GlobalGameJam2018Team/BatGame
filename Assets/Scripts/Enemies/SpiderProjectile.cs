using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderProjectile : MonoBehaviour
{
    public float projectile_speed = 1.0f;
    public float slow_decrease = 2.0f;
    public float slow_time = 3.0f;
    public GameObject player;

    private Vector3 direction;

    private void Start()
    {
        direction = player.transform.position - transform.position;
    }

    private void Update()
    {
        transform.position += direction * Time.deltaTime * projectile_speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 11 && collision.gameObject.layer != 0)   //If its not an enemy or default
        {
            if (collision.gameObject == player.gameObject)    //If its player
                player.GetComponent<PlayerController2>().SlowDebuff(slow_decrease, slow_time);

            Object.Destroy(gameObject);
        }
    }
}
