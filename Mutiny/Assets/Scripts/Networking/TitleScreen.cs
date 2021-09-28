using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public Launcher launcher;

    public void MenuScreen()
    {
        SceneManager.LoadScene("Menu 1");
    }
}
