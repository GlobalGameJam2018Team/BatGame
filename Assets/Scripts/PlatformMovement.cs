using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Vector3 positionA;
    public Vector3 positionB;

    public float min_distance = 1.0f;
    public float speed = 1.0f;

    private Vector3 direction;
	
	void Update ()
    {
        if ((transform.position - positionA).magnitude <= min_distance)
            direction = (positionB - transform.position).normalized;
        else if ((transform.position - positionB).magnitude <= min_distance)
            direction = (positionA - transform.position).normalized;

        transform.position += direction * Time.deltaTime * speed;
    }
}
