using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseUI : MonoBehaviour
{
    public GameObject lose_panel;

    public void LostGame(GameObject killed_by)
    {
        lose_panel.SetActive(true);
        if (killed_by.tag == "Spider")
        {

        }

    }
}
