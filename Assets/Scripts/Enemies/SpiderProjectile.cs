using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderProjectile : MonoBehaviour
{
    public float projectile_speed = 1.0f;
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
        if (collision.gameObject.layer != 11)   //If its not an enemy
        {
            if (collision.gameObject.layer == 9)    //If its player
            {
                //TODO
            }
            Object.Destroy(gameObject);
        }
    }
}
