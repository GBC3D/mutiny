using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Launcher launcher;

    public void JoinMatch()
    {
        launcher.Join();
    }

    public void CreateMatch()
    {
        launcher.Create();
    }

    public void enterSettingsMenu()
    {
        SceneManager.LoadScene("Settings Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
