using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarScript : MonoBehaviour {

    public float sonar_radius = 20;
    public float sonar_angle = 90;
	

    public Vector3 DirFromAngle(float angle_deg)
    {
        return new Vector3(Mathf.Sin(angle_deg * Mathf.Deg2Rad), 0, Mathf.Cos(angle_deg * Mathf.Deg2Rad));
    }
}
