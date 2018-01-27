using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpdateSonar : MonoBehaviour {

    public Material material_a;
    public float mat_a_int_value = 0.0f;
    public float mat_a_ext_value = 5.0f;
    public Material material_b;
    public float mat_b_int_value = 0.0f;
    public float mat_b_ext_value = 5.0f;
    public Material material_c;
    public float mat_c_int_value = 0.0f;
    public float mat_c_ext_value = 5.0f;


    public float loop_rate = 2.5f;
    public float animation_speed = 1.0f;

    private void Start()
    {
        material_a.SetFloat("_InnerRingDiameter", mat_a_int_value);
        material_a.SetFloat("_ExternRingDiameter", mat_a_ext_value);

        material_b.SetFloat("_InnerRingDiameter", mat_b_int_value);
        material_b.SetFloat("_ExternRingDiameter", mat_b_ext_value);

        material_c.SetFloat("_InnerRingDiameter", mat_c_int_value);
        material_c.SetFloat("_ExternRingDiameter", mat_c_ext_value);
    }

    void Update()
    {
        material_a.SetFloat("_ExternRingDiameter", material_a.GetFloat("_ExternRingDiameter") - animation_speed * Time.deltaTime);
        if(material_a.GetFloat("_ExternRingDiameter") < 0.0001f)
        {
            material_a.SetFloat("_ExternRingDiameter", mat_a_ext_value);
        }

        material_b.SetFloat("_ExternRingDiameter", material_b.GetFloat("_ExternRingDiameter") - animation_speed * Time.deltaTime * 0.3f);
        if (material_b.GetFloat("_ExternRingDiameter") < 0.0001f)
        {
            material_b.SetFloat("_ExternRingDiameter", mat_b_ext_value);
        }

        material_c.SetFloat("_ExternRingDiameter", material_c.GetFloat("_ExternRingDiameter") - animation_speed * Time.deltaTime * 0.15f);
        if (material_c.GetFloat("_ExternRingDiameter") < 0.0001f)
        {
            material_c.SetFloat("_ExternRingDiameter", mat_c_ext_value);
        }
    }

    private void OnApplicationQuit()
    {
        material_a.SetFloat("_InnerRingDiameter", mat_a_int_value);
        material_a.SetFloat("_ExternRingDiameter", mat_a_ext_value);

        material_b.SetFloat("_InnerRingDiameter", mat_b_int_value);
        material_b.SetFloat("_ExternRingDiameter", mat_b_ext_value);

        material_c.SetFloat("_InnerRingDiameter", mat_c_int_value);
        material_c.SetFloat("_ExternRingDiameter", mat_c_ext_value);
    }

}
