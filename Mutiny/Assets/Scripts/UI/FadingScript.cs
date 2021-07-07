using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingScript : MonoBehaviour
{
    public Image fadingImage;
    public GameObject player;
    public float newX;
    public float newY;
    public float newZ;

    // Start is called before the first frame update
    void Start()
    {
        fadingImage.canvasRenderer.SetAlpha(0.0f);
    }

    public void GoToNextScene()
    {
        StartCoroutine(waiter());
    }

    public void FadeIn()
    {
        fadingImage.CrossFadeAlpha(1, 2f, false);
    }
    
    public void FadeOut()
    {
        fadingImage.CrossFadeAlpha(0, 2f, false);
    }

    IEnumerator waiter()
    {
        FadeIn();
        yield return new WaitForSecondsRealtime(2);
        player.transform.position = new Vector3(newX, newY, newZ);
        FadeOut();
    }
}
