using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private SonarScript sonar;
    public SonarFx sonar_fx;
    AudioSource audio;

    public float speed = 1.0f;
    public float detection_distance = 10.0f;
    private bool chasing = false;

    NavMeshAgent agent;
    private float timer = 0.0f;
    Animator anim;

    private void Start()
    {
        sonar = player.GetComponent<SonarScript>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.speed = speed;
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!chasing && Input.GetKeyDown(KeyCode.Space) && (player.transform.position - transform.position).magnitude <= detection_distance)
        {
            List<Transform> transformations = sonar.GetVisibleTargets();
            foreach (Transform t in transformations)
                if (t == transform)
                {
                    audio.Play();
                    chasing = true;
                }
        }
        if (chasing)
        {
            //Update destination every second
            if (timer >= 1.0f)
            {
                agent.SetDestination(new Vector3(player.transform.position.x, 0.0f, player.transform.position.z));
                timer = 0.0f;
            }
            timer += Time.deltaTime;

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
