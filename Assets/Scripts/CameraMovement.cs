using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CameraMovement : MonoBehaviour
{
    public float camera_distance_to_player = 10.0f;
    public GameObject player;
    public float speed = 0.001f;
    public float minRange = 1.0f;
    public float maxRange = 4.0f;
    void Update()
    {        
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y + camera_distance_to_player, player.transform.position.z);
        Vector3 diff = playerPos - transform.position;

        if(diff.magnitude > minRange && diff.magnitude< maxRange)
        transform.position += diff * speed;

        if(diff.magnitude>= maxRange)
        {
            transform.position = playerPos - diff.normalized * maxRange;
        }
      }
}