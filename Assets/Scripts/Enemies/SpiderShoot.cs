using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderShoot : MonoBehaviour
{
    private NavMeshAgent agent;

    public Vector3 positionA;
    public Vector3 positionB;
    public float min_distance = 1.0f;

    public float angle_cone_vision = 70.0f;
    public float projectile_speed = 1.0f;
    public float shoot_cooldown = 2.0f;
    private float shoot_timer = 0.0f;

    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}
	
	void Update ()
    {
        //MOVEMENT
        Vector3 actual_pos = transform.position;
        actual_pos.y = 0;
       //For if we need to avoid the rotation: gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
        if ((actual_pos - positionA).magnitude < min_distance)
            GoToPos(positionB);
        else if ((actual_pos - positionB).magnitude < min_distance)
            GoToPos(positionA);
        //---------------

        //VISION

        //---------------
    }

    void GoToPos(Vector3 new_pos)
    {
        agent.SetDestination(new_pos);
    }
}
