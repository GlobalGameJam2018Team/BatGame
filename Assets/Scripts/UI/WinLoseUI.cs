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
        spider_img.SetActive(false);
        bad_bat_img.SetActive(false);
        snake_img.SetActive(false);
        stalactite_img.SetActive(false);
        spikes_img.SetActive(false);

        if (killed_by.tag == "Spider")
            spider_img.SetActive(true);
        else if (killed_by.tag == "EnemyBat")
            bad_bat_img.SetActive(true);
        else if (killed_by.tag == "Snake")
            snake_img.SetActive(true);
        else if (killed_by.tag == "Stalactite")
            stalactite_img.SetActive(true);
        else if (killed_by.tag == "Spikes")
            spikes_img.SetActive(true);
    }
}
