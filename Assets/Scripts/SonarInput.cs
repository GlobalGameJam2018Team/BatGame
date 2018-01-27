using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarInput : MonoBehaviour {

    // Use this for initialization
  
    Renderer rend;
    //public Material mat;
    float sonarTime = 0.0f;
	void Start () {
        rend = GetComponent<Renderer>();
        //rend.material.shader = Shader.Find("Custom/SonarFX");
        //sonarMat = GetComponent<Material>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            sonarTime = 0.0f;
           
        }
        sonarTime += Time.deltaTime;
        rend.material.SetFloat("_SonarTime", sonarTime);
        rend.material.SetVector("_SonarWaveVector", new Vector4(transform.position.x, transform.position.y, transform.position.z, 1));
    }
}
