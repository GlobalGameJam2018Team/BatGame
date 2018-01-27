using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void HelpButton()
    {
        SceneManager.LoadScene(3);
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
