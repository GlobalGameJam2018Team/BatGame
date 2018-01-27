using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderShoot : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;

    public Vector3 positionA;
    public Vector3 positionB;
    private Vector3 position_temp;
    public float spider_speed = 1.0f;
    public float min_distance = 1.0f;

    private Camera camera;
    private bool player_detected = false;

    public GameObject spider_projectile;
    public float projectile_speed = 1.0f;
    public float shoot_cooldown = 2.0f;
    private float shoot_timer = 0.0f;

    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        camera = GetComponent<Camera>();
	}
	
	void Update ()
    {
        //MOVEMENT
        if (!player_detected)
        {
            Vector3 actual_pos = transform.position;
            actual_pos.y = 0;
            //For if we need to avoid the rotation: gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
            if ((actual_pos - positionA).magnitude < min_distance)
                GoToPos(positionB);
            else if ((actual_pos - positionB).magnitude < min_distance)
                GoToPos(positionA);
        }
        //---------------

        //VISION
        if (GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(camera), player.GetComponent<Collider>().bounds))
        {
            player_detected = true;
            position_temp = agent.destination;
            agent.Stop();
            Debug.Log("DETECTED");
        }
        else
        {
            if (player_detected == true)
            {
                agent.Resume();
                GoToPos(position_temp);
            }
            player_detected = false;
        }
        //---------------

        //SHOOT
        if(shoot_timer >= shoot_cooldown)
        {
            shoot_timer = 0.0f;

        }
        shoot_timer += Time.deltaTime;
        //---------------
    }

    void GoToPos(Vector3 new_pos)
    {
        agent.speed = spider_speed;
        agent.SetDestination(new_pos);
    }
}

public class Projectile
{
    private float speed = 1.0f;

    public Projectile CreateProjectile(float projectile_speed)
    {
        speed = projectile_speed;
        return this;
    }
}