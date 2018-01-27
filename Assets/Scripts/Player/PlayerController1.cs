
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public bool acceleration = true;
    public float speed_up_down = 0.2f;
    public float speed_right_left = 0.2f;

    public float max_speed_up_down = 2.5f;
    public float max_speed_right_left = 2.5f;

    private Vector2 velocity_vector = new Vector2(0, 0);

    void Update()
    {
        //With Acceleration Movement
        if (acceleration == true)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                velocity_vector.y += Time.deltaTime * speed_up_down;

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                velocity_vector.y -= Time.deltaTime * speed_up_down;

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                velocity_vector.x += Time.deltaTime * speed_up_down;

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                velocity_vector.x -= Time.deltaTime * speed_up_down;

            if (velocity_vector.x > max_speed_right_left)
                velocity_vector.x = max_speed_right_left;
            if (velocity_vector.x < -max_speed_right_left)
                velocity_vector.x = -max_speed_right_left;
            if (velocity_vector.y > max_speed_up_down)
                velocity_vector.y = max_speed_up_down;
            if (velocity_vector.y < -max_speed_up_down)
                velocity_vector.y = -max_speed_up_down;
        }

        //Without acceleration movement ----------------------------------
        else
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                velocity_vector.y = max_speed_up_down;
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
                velocity_vector.y = 0.0f;

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                velocity_vector.y = -max_speed_up_down;
            if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
                velocity_vector.y = 0.0f;

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                velocity_vector.x = max_speed_right_left;
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
                velocity_vector.x = 0.0f;

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                velocity_vector.x = -max_speed_right_left;
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
                velocity_vector.x = 0.0f;
        }
        transform.position += new Vector3(velocity_vector.x, 0, velocity_vector.y); //since everything is rotated 90 degrees in X axis so the map can have a nav mesh
    }
}