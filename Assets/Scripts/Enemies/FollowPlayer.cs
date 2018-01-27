using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private SonarScript sonar;
    public float speed = 1.0f;
    public float detection_distance = 10.0f;
    private bool chasing = false;

    NavMeshAgent agent;
    private float timer = 0.0f;

    //Random between chasing using a pathfinding or just stright in a line to create variants
    private float random = 0.0f;

    private void Start()
    {
        sonar = player.GetComponent<SonarScript>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!chasing)
        {
            List<Transform> transformations = sonar.GetVisibleTargets();
            foreach (Transform t in transformations)
                if (t == transform)
                {
                    chasing = true;
                    random = Random.Range(0.0f, 1.0f);
                }
        }
        else
        {
            if (random <= 0.5f)
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            else
            {
                //Update destination every second
                if (timer >= 1.0f)
                {
                    agent.SetDestination(player.transform.position);
                    timer = 0.0f;
                }
                timer += Time.deltaTime;
            }

            if ((player.transform.position - transform.position).magnitude >= detection_distance)
                chasing = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detection_distance);
    }
}
