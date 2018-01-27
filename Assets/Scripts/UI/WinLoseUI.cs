using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseUI : MonoBehaviour
{
    public GameObject lose_panel;

    public GameObject spider_img;
    public GameObject bad_bat_img;
    public GameObject snake_img;
    public GameObject stalactite_img;
    public GameObject spikes_img;

    public void LostGame(GameObject killed_by)
    {
        lose_panel.SetActive(true);
        if (killed_by.tag == "Spider")
        {

        }

    }
}
