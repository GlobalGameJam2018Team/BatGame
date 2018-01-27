using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject lose_panel;

    public GameObject spider_img;
    public GameObject bad_bat_img;
    public GameObject snake_img;
    public GameObject stalactite_img;
    public GameObject spikes_img;

    public GameObject pause_menu_panel;
    private bool game_paused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && game_paused)
            ResumeGame();
        else if (Input.GetKeyDown(KeyCode.Escape) && !game_paused)
        {
            game_paused = true;
            pause_menu_panel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void LostGame(GameObject killed_by)
    {
        Time.timeScale = 0.0f;
        lose_panel.SetActive(true);

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


    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void ResumeGame()
    {
        game_paused = false;
        Time.timeScale = 1.0f;
        pause_menu_panel.SetActive(false);
    }
}
