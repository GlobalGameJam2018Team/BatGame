using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SnakeLogic : MonoBehaviour {

    public GameObject player;
    private NavMeshAgent agent;

    public float speed = 0.5f;
   
    Camera camera;

    public Vector3 positionA;
    public Vector3 positionB;

    public float viewAngle = 50.0f;

    public float snakeSpeed = 1.0f;
    public float min_distance = 0.02f;

    private bool player_detected = false;
    private Vector3 playerPosition = new Vector3(0,0,0);
    private bool objectiveReached = false;

    // Use this for initialization
    void Start () {
        camera = GetComponent<Camera>();
        agent = GetComponent<NavMeshAgent>();
        GoToPos(positionB);
    }
	
	// Update is called once per frame
	void Update () {

        if (player_detected == false)
        {
          
                Vector3 actual_pos = transform.position;
                actual_pos.y = 0;
            //For if we need to avoid the rotation: gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
            if ((actual_pos - positionA).magnitude <= min_distance)
            {
                transform.eulerAngles = new Vector3(0, -viewAngle, 0);
                GoToPos(positionB);
            }
            else if ((actual_pos - positionB).magnitude <= min_distance)
            {
                transform.eulerAngles = new Vector3(0, viewAngle, 0);
                GoToPos(positionA);
            }
            

            if (GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(camera), player.GetComponent<Collider>().bounds))
            {

                player_detected = true;
                playerPosition = player.transform.position;
                Debug.Log("DETECTED");
            }
        }

        else
        {
            if (playerPosition != Vector3.zero && !objectiveReached)
            {
                Vector3 diff = playerPosition - transform.position;
                gameObject.transform.position += diff.normalized * speed;
                if (diff.magnitude < 0.75f)
                    objectiveReached = true;

            }
            if (objectiveReached)
            {
                transform.position += new Vector3(-0.05f, 0, -0.1f);
                
            }
        }


    }
 
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 10 && objectiveReached)
        {
            objectiveReached = false;
            player_detected = false;
            transform.eulerAngles = new Vector3(0, -viewAngle, 0);
            GoToPos(positionB);
        }
    }

    void GoToPos(Vector3 new_pos)
    {
      
        agent.SetDestination(new_pos);
    }

}
