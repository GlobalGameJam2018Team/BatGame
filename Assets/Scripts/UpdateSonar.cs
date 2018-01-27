using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpdateSonar : MonoBehaviour {
    public Material material;
    public Transform target;
    void Update()
    {
        material.SetVector("Target position", new Vector4(target.position.x, target.position.y, target.position.z, 0));
    }
    
}
