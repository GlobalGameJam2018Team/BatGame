using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeLogic : MonoBehaviour {

    public GameObject player;
    public float speed = 0.5f;
    Camera camera;
    private bool player_detected = false;
    private Vector3 playerPosition = new Vector3(0,0,0);
    // Use this for initialization
    void Start () {
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

        if (player_detected == false)
        {
            if (GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(camera), player.GetComponent<Collider>().bounds))
            {

                player_detected = true;
                playerPosition = player.transform.position;
                Debug.Log("DETECTED");
            }
        }

        else
        {
            if (playerPosition != Vector3.zero)
            {
                Vector3 diff = playerPosition - transform.position;
                gameObject.transform.position += diff.normalized * speed;
                if (diff.magnitude < 0.5f)
                    Destroy(gameObject);
            }
        }

    }
}
