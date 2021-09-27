using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionChanger : MonoBehaviour
{
    //Changes the resolution based on the valuein the dropdown box
    public void ChangeResolution()
    {
        int i = GetComponent<Dropdown>().value;
        switch(i)
        {
            case 0:
                break;
            case 1:
                Screen.SetResolution(1280, 720, false);
                break;
            case 2:
                Screen.SetResolution(1366, 768, false);
                break;
            case 3:
                Screen.SetResolution(1920, 1080, false);
                break;
            default:
                Screen.SetResolution(1280, 720, false);
                break;
        }
    }
}
