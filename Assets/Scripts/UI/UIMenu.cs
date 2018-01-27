using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour {

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void HelpButton()
    {

    }

    public void CreditsButton()
    {

    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
