using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class SonarScript : MonoBehaviour {

    public float sonar_radius = 20;
    [Range(0,360)]
    public float sonar_angle = 90;

    public LayerMask target_mask;
    public LayerMask obstacle_mask;

    [HideInInspector]
    public List<Transform> visible_targets = new List<Transform>();

    private void Start()
    {
        StartCoroutine("FindTargetsWithDelay", 0.2f);
    }
    IEnumerator FindTargetsWithDelay(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        visible_targets.Clear();

        Collider[] targets_in_view_rad = Physics.OverlapSphere(transform.position, sonar_radius, target_mask);

        for(int k = 0; k < targets_in_view_rad.Length; k++)
        {
            Transform target = targets_in_view_rad[k].transform;

            Vector3 dir_to_target = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dir_to_target) < sonar_angle / 2)
            {
                float dist_to_target = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position,dir_to_target,dist_to_target,obstacle_mask))
                {
                    visible_targets.Add(target);
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angle_deg, bool angle_is_global)
    {
        if(!angle_is_global)
        {
            angle_deg += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angle_deg * Mathf.Deg2Rad), 0, Mathf.Cos(angle_deg * Mathf.Deg2Rad));
    }
}
