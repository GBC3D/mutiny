using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteSetter : MonoBehaviour
{
    [SerializeField] private AnimatorOverrideController[] overrideControllers;
    [SerializeField] private AnimatorOverrider overrider;
    [SerializeField] private int defaultSkinIndex;

    private void Start()
    {
        Set(defaultSkinIndex);
    }

    public void Set(int i)
    {
        if (i >= overrideControllers.Length)
            i = 0;
        if (overrideControllers.Length <= 0) {
            Debug.LogError("Override Controllers array is empty.");
            return;
        }
        overrider.SetAnimations(overrideControllers[i]);
    }
}
