using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyUI : MonoBehaviour {
    public Image bar;
    public SonarFx sonar_fx;
    public GameObject parent;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        float value = sonar_fx.GetAbsoluteCDTime();
        if (sonar_fx.GetCDActive())
        {
            parent.SetActive(false);
        }
        else
        {
            parent.SetActive(true);
            bar.fillAmount = value;
        }
    }
}