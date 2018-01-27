using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SonarScript))]
public class SonarEditor : Editor {

    private void OnSceneGUI()
    {
        SonarScript sonar = (SonarScript)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(sonar.transform.position, Vector3.up, Vector3.forward, 360, sonar.sonar_radius);

        Vector3 sonar_angle_A = sonar.DirFromAngle(-sonar.sonar_angle / 2, false);
        Vector3 sonar_angle_B = sonar.DirFromAngle(sonar.sonar_angle / 2, false);

        Handles.DrawLine(sonar.transform.position, sonar.transform.position + sonar_angle_A * sonar.sonar_radius);
        Handles.DrawLine(sonar.transform.position, sonar.transform.position + sonar_angle_B * sonar.sonar_radius);

        Handles.color = Color.red;
        foreach(Transform visible_target in sonar.visible_targets)
        {
            Handles.DrawLine(sonar.transform.position, visible_target.position);
        }
    }
}
