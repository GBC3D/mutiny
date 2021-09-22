using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkinSelectionCreator : MonoBehaviour
{
    public Text skinName;
    public Image skinImage;
    public int skinIndex;

    public PlayerSkin skin;

    public PlayerSpriteSetter playerSpriteSetter;

    public void Start()
    {
        if (!skinName)
            skinName = GetComponentInChildren<Text>();
        if (!skinImage)
            skinImage = GetComponentInChildren<Image>();
    }

    public void Setup(PlayerSkin newSkin, PlayerSpriteSetter _playerSpriteSetter, int _skinIndex)
    {
        skin = newSkin;
        skinImage.sprite = skin.showcaseImage;
        skinName.text = skin.skinName;
        skinIndex = _skinIndex;

        playerSpriteSetter = _playerSpriteSetter;
    }

    public void SelectSkin()
    {
        if (playerSpriteSetter) 
            playerSpriteSetter.Set(skin.skin, skinIndex);
    }
}
