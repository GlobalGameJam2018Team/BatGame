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
    public float mesh_resolution;

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
    void DrawFielOfView()
    {
        int stepCount = Mathf.RoundToInt(sonar_angle * mesh_resolution);
        float step_angle_size = sonar_angle / stepCount;
        List<Vector3> view_points = new List<Vector3>();
        for (int i = 0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - sonar_angle / 2 + step_angle_size * i;
            ViewCastInfo new_view_cast = ViewCast(angle);
            view_points.Add(new_view_cast.point);
        }


    }

    ViewCastInfo ViewCast(float global_angle)
    {
        Vector3 direction = DirFromAngle(global_angle,true);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, sonar_radius, obstacle_mask))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, global_angle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position + direction * sonar_radius, hit.distance, global_angle);

        }
    }
    public struct ViewCastInfo
    {
        public bool hit;
        public Vector3 point;
        public float distance;
        public float angle;
        public ViewCastInfo(bool _hit, Vector3 _point, float _distance, float _angle)
        {
            hit = _hit;
            point = _point;
            distance = _distance;
            angle = _angle;
        }
    }
}
