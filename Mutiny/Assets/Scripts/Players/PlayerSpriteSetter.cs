using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteSetter : MonoBehaviour
{
    [SerializeField] public SkinCollection skinCollection;
    [SerializeField] private AnimatorOverrider overrider;
    [SerializeField] private int defaultSkinIndex;
    [SerializeField] Animator animator;

    private void Awake()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
    }

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
        overrider.SetAnimations(skinCollection.skins[i].skin, i);
    }

    public void Set(AnimatorOverrideController animatorOverrideController, int skinIndex)
    {
        if (animatorOverrideController != null)
        {
            overrider.SetAnimations(animatorOverrideController, skinIndex);
            if (animator.GetInteger("EquipSkin") != skinIndex)
                animator.SetInteger("EquipSkin", skinIndex);
        } else
        {
            Debug.LogError("Error -trying to set null skin");
        }
    }
}
