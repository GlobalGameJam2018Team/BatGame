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
        Handles.DrawWireArc(sonar.transform.position, Vector3.forward, Vector3.up, 360, sonar.sonar_radius);
    }
}
