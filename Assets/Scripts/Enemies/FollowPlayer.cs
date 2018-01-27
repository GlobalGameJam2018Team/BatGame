using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private SonarScript sonar;
    public float speed = 1.0f;

    private void Start()
    {
        sonar = player.GetComponent<SonarScript>();
    }

    private void Update()
    {
        List<Transform> transformations = sonar.GetVisibleTargets();
        foreach (Transform t in transformations)
        {
            if (t == transform)
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
