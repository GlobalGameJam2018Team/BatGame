using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float camera_distance_to_player = 10.0f;
    public GameObject player;
    public float speed = 1.0f;
    void Update()
    {
        //Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.z + camera_distance_to_player, player.transform.position.y);
        //Vector3 diff = transform.position - playerPos;

        //transform.position += diff;

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + camera_distance_to_player, player.transform.position.z);
    }
}