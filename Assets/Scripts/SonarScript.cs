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
    public int edge_resolution_iteration;
    public float edge_distance_limit;
    public MeshFilter view_mesh_filter;
    Mesh view_mesh;
    [HideInInspector]
    public List<Transform> visible_targets = new List<Transform>();

    private void Start()
    {
        view_mesh = new Mesh();
        StartCoroutine("FindTargetsWithDelay", 0.2f);
        view_mesh_filter.mesh = view_mesh;
    }

    private void Update()
    {
        DrawFielOfView();
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
        return new Vector3(Mathf.Sin(angle_deg * Mathf.Deg2Rad),  0, Mathf.Cos(angle_deg * Mathf.Deg2Rad));
    }
    void DrawFielOfView()
    {
        int stepCount = Mathf.RoundToInt(sonar_angle * mesh_resolution);
        float step_angle_size = sonar_angle / stepCount;
        List<Vector3> view_points = new List<Vector3>();
        ViewCastInfo old_view_cast = new ViewCastInfo();
        for (int i = 0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - sonar_angle / 2 + step_angle_size * i;
            ViewCastInfo new_view_cast = ViewCast(angle);
            if(i>0)
            {
                bool edge_excede = Mathf.Abs(old_view_cast.distance - new_view_cast.distance) > edge_distance_limit;
                if(old_view_cast.hit!=new_view_cast.hit||old_view_cast.hit&&new_view_cast.hit && edge_excede )
                   {
                    EdgeInfo edge = FindEdge(old_view_cast, new_view_cast);
                    if(edge.point_A!=Vector3.zero)
                    {
                        view_points.Add(edge.point_A);
                    }
                    if (edge.point_B != Vector3.zero)
                    {
                        view_points.Add(edge.point_B);
                    }
                }
            }
            view_points.Add(new_view_cast.point);
            old_view_cast = new_view_cast;
        }

        int vertex_count = view_points.Count + 1;
        Vector3[] vertices = new Vector3[vertex_count];
        int[] triangles = new int[(vertex_count - 2) * 3];
        vertices[0] = Vector3.zero;
        for(int i = 0; i < vertex_count - 1; i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(view_points[i]);

            if (i < vertex_count - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }

        }
        view_mesh.Clear();
        view_mesh.vertices = vertices;
        view_mesh.triangles = triangles;
        view_mesh.RecalculateNormals();
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

    EdgeInfo FindEdge(ViewCastInfo min_view_cast,ViewCastInfo max_view_cast)
    {
        float min_angle = min_view_cast.angle;
        float max_angle = max_view_cast.angle;
        Vector3 min_point = Vector3.zero;
        Vector3 max_point = Vector3.zero;
        for(int i=0;i<edge_resolution_iteration;i++)
        {
            float angle = (min_angle + max_angle) / 2;
            ViewCastInfo new_view_cast = ViewCast(angle);
            bool edge_excede = Mathf.Abs(min_view_cast.distance - max_view_cast.distance) > edge_distance_limit;

            if (new_view_cast.hit==min_view_cast.hit&&!edge_excede)
            {
                min_angle = angle;
                min_point = new_view_cast.point;
            }
            else
            {
                max_angle = angle;
                max_point = new_view_cast.point;
            }
        }
        return new EdgeInfo(min_point, max_point);
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
    public struct EdgeInfo
    {
        public Vector3 point_A;
        public Vector3 point_B;

        public EdgeInfo(Vector3 _point_A,Vector3 _point_B)
        {
            point_A = _point_A;
            point_B = _point_B;
        }
    }
}
