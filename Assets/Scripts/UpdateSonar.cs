using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpdateSonar : MonoBehaviour {

    public float min_int_value = 0;
    public float max_int_value = 1.0f;

    public float min_ext_value = 0.6f;
    public float max_ext_value = 12.0f;

    public Material material_a;
    [Range(0,1)]
    public float mat_a_int_value = 0.0f;
    [Range(0, 1)]
    public float mat_a_int_value_finish = 0.0f;
    float mat_a_int_current;

    [Range(0, 1)]
    public float mat_a_ext_value = 5.0f;
    [Range(0, 1)]
    public float mat_a_ext_value_finish = 5.0f;
    float mat_a_ext_current;

    public Material material_b;
    [Range(0, 1)]
    public float mat_b_int_value = 0.0f;
    [Range(0, 1)]
    public float mat_b_int_value_finish = 0.0f;
    float mat_b_int_current;

    [Range(0, 1)]
    public float mat_b_ext_value = 5.0f;
    [Range(0, 1)]
    public float mat_b_ext_value_finish = 5.0f;
    float mat_b_ext_current;

    public Material material_c;
    [Range(0, 1)]
    public float mat_c_int_value = 0.0f;
    [Range(0, 1)]
    public float mat_c_int_value_finish = 0.0f;
    float mat_c_int_current;

    [Range(0, 1)]
    public float mat_c_ext_value = 5.0f;
    [Range(0, 1)]
    public float mat_c_ext_value_finish = 5.0f;
    float mat_c_ext_current;

   
    public float loop_rate = 2.5f;
    public float animation_speed = 1.0f;

    private void Start()
    {
        mat_a_int_current = mat_a_int_value;
        material_a.SetFloat("_InnerRingDiameter", mat_a_int_current* max_int_value);
        mat_a_ext_current = mat_a_ext_value;
        material_a.SetFloat("_ExternRingDiameter", mat_a_ext_current* max_ext_value);

        mat_b_int_current = mat_b_int_value;
        material_b.SetFloat("_InnerRingDiameter", mat_b_int_current * max_int_value);
        mat_b_ext_current = mat_b_ext_value;
        material_b.SetFloat("_ExternRingDiameter", mat_b_ext_current * max_ext_value);

        mat_c_int_current = mat_c_int_value;
        material_c.SetFloat("_InnerRingDiameter", mat_c_int_current * max_int_value);
        mat_c_ext_current = mat_c_ext_value;
        material_c.SetFloat("_ExternRingDiameter", mat_c_ext_current * max_ext_value);
    }

    void Update()
    {
        mat_a_int_current += animation_speed * Time.deltaTime;
        material_a.SetFloat("_InnerRingDiameter", mat_a_int_current * max_int_value);
        if (mat_a_int_current>= mat_a_int_value_finish)
        {
            mat_a_int_current = mat_a_int_value;
            material_a.SetFloat("_InnerRingDiameter", mat_a_int_current * max_int_value);
        }
        mat_a_ext_current += animation_speed * Time.deltaTime;
        material_a.SetFloat("_ExternRingDiameter", mat_a_ext_current * max_ext_value);
        if (material_a.GetFloat("_ExternRingDiameter") >= mat_a_ext_value_finish)
        {
            mat_a_ext_current = mat_a_ext_value;
            material_a.SetFloat("_ExternRingDiameter", mat_a_ext_current * max_ext_value);
        }
        /*
        material_a.SetFloat("_InnerRingDiameter", material_a.GetFloat("_InnerRingDiameter") - animation_speed * Time.deltaTime*0.05f);
        if (material_a.GetFloat("_InnerRingDiameter") < mat_a_int_value_finish)
        {
            material_a.SetFloat("_InnerRingDiameter", mat_a_int_value);
        }
        material_a.SetFloat("_ExternRingDiameter", material_a.GetFloat("_ExternRingDiameter") - animation_speed * Time.deltaTime);
        if(material_a.GetFloat("_ExternRingDiameter") < mat_a_ext_value_finish)
        {
            material_a.SetFloat("_ExternRingDiameter", mat_a_ext_value);
        }
        material_b.SetFloat("_InnerRingDiameter", material_b.GetFloat("_InnerRingDiameter") - animation_speed * Time.deltaTime );
        if (material_b.GetFloat("_InnerRingDiameter") < mat_b_int_value_finish)
        {
            material_b.SetFloat("_InnerRingDiameter", mat_b_int_value);
        }
        material_b.SetFloat("_ExternRingDiameter", material_b.GetFloat("_ExternRingDiameter") - animation_speed * Time.deltaTime );
        if (material_b.GetFloat("_ExternRingDiameter") < mat_b_ext_value_finish)
        {
            material_b.SetFloat("_ExternRingDiameter", mat_b_ext_value);
        }
        material_c.SetFloat("_InnerRingDiameter", material_c.GetFloat("_InnerRingDiameter") - animation_speed * Time.deltaTime );
        if (material_c.GetFloat("_InnerRingDiameter") < mat_c_int_value_finish)
        {
            material_c.SetFloat("_InnerRingDiameter", mat_c_int_value);
        }
        material_c.SetFloat("_ExternRingDiameter", material_c.GetFloat("_ExternRingDiameter") - animation_speed * Time.deltaTime );
        if (material_c.GetFloat("_ExternRingDiameter") < mat_c_ext_value_finish)
        {
            material_c.SetFloat("_ExternRingDiameter", mat_c_ext_value);
        }
        */
    }

    private void OnApplicationQuit()
    {
        mat_a_int_current = mat_a_int_value;
        material_a.SetFloat("_InnerRingDiameter", mat_a_int_current * max_int_value);
        mat_a_ext_current = mat_a_ext_value;
        material_a.SetFloat("_ExternRingDiameter", mat_a_ext_current * max_ext_value);

        mat_b_int_current = mat_b_int_value;
        material_b.SetFloat("_InnerRingDiameter", mat_b_int_current * max_int_value);
        mat_b_ext_current = mat_b_ext_value;
        material_b.SetFloat("_ExternRingDiameter", mat_b_ext_current * max_ext_value);

        mat_c_int_current = mat_c_int_value;
        material_c.SetFloat("_InnerRingDiameter", mat_c_int_current * max_int_value);
        mat_c_ext_current = mat_c_ext_value;
        material_c.SetFloat("_ExternRingDiameter", mat_c_ext_current * max_ext_value);
    }

}
