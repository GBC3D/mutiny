using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteSetter : MonoBehaviour
{
    [SerializeField] private SkinCollection skinCollection;
    [SerializeField] private AnimatorOverrider overrider;
    [SerializeField] private int defaultSkinIndex;

    private void Start()
    {
        // Set(defaultSkinIndex);
        SkinSelector skinSelector = FindObjectOfType<SkinSelector>();
        if (skinSelector)
        {
            skinSelector.SetPlayer(this);
            Debug.Log("Set PlayerSpriteSetter");
        } else
        {
            Debug.Log("Did not find SkinSelector");
        }
    }

    public void Set(int i)
    {
        if (i >= skinCollection.skins.Count)
            i = 0;
        if (skinCollection.skins.Count <= 0) {
            Debug.LogError("Override Controllers array is empty.");
            return;
        }
        overrider.SetAnimations(skinCollection.skins[i].skin);
    }

    public void Set(AnimatorOverrideController animatorOverrideController)
    {
        if (animatorOverrideController != null)
        {
            overrider.SetAnimations(animatorOverrideController);
        } else
        {
            Debug.LogError("Error -trying to set null skin");
        }
    }
}
