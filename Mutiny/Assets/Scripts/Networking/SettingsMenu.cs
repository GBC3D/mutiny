using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public Launcher launcher;

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu 1");
    }
}
