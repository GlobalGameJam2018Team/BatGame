﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderLogic : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;
    AudioSource audio;

    public Vector3 positionA;
    public Vector3 positionB;
    private Vector3 position_temp;
    private int direction_x = 1;
    public float spider_speed = 1.0f;
    public float min_distance = 1.0f;

    private Camera camera;
    private bool player_detected = false;

    private Animator anim;
    public GameObject spider_projectile;
    public float shoot_cooldown = 2.0f;
    private float shoot_timer = 0.0f;

    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        camera = GetComponentInChildren<Camera>();
        anim = GetComponentInChildren<Animator>();
        agent.isStopped = false;
        agent.updateRotation = false;
        audio = GetComponent<AudioSource>();
    }

    void Update ()
    {
        //MOVEMENT
        if (!player_detected)
        {
            Vector3 actual_pos = transform.position;
            actual_pos.y = 0;
            if ((actual_pos - positionA).magnitude <= min_distance)
            {
                direction_x = -1;
                GoToPos(positionB);
            }
            else if ((actual_pos - positionB).magnitude <= min_distance)
            {
                direction_x = 1;
                GoToPos(positionA);
            }
        }
        //---------------

        //VISION
        if (GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(camera), player.GetComponent<Collider>().bounds))
        {
            player_detected = true;
            position_temp = agent.destination;
            agent.isStopped = true;
            anim.SetBool("attacking", true);
            Debug.Log("DETECTED");
        }
        else
        {
            if (player_detected == true)
            {
                agent.isStopped = false;
                GoToPos(position_temp);
            }
            player_detected = false;
            anim.SetBool("attacking", false);
        }
        //---------------

        //SHOOT
        if (player_detected)
        {
            if (shoot_timer >= shoot_cooldown)
            {
                audio.Play();
                shoot_timer = 0.0f;
                GameObject projectile = GameObject.Instantiate(spider_projectile);
                projectile.transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z) + 2.0f * transform.forward;
                projectile.SetActive(true);
            }
            shoot_timer += Time.deltaTime;
        }
        else
            shoot_timer = 0.0f;
        //---------------
        gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
    }

    void GoToPos(Vector3 new_pos)
    {
        agent.speed = spider_speed;
        agent.SetDestination(new Vector3(new_pos.x, 0.0f, new_pos.z));
    }
}