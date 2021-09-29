using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    public double volume = 0.5;
    AudioSource myAudio;
    
    //sets the game volume to a specific value
    public void setVolume()
    {

    }
    //changes the game volume
    public void changeVolume(double vol)
    {
        volume = vol;
    }
}
