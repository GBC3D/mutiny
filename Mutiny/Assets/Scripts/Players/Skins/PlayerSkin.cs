using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skin", menuName = "Skins/Skin")]
public class PlayerSkin : ScriptableObject
{
    public AnimatorOverrideController skin;

    public Sprite showcaseImage;

    public string skinName;
}
