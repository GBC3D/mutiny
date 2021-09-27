using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorOverrider : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAnimations(AnimatorOverrideController overrideController, int skinIndex)
    {
        _animator.runtimeAnimatorController = overrideController;
        if (_animator.GetInteger("EquipSkin") != skinIndex)
            _animator.SetInteger("EquipSkin", skinIndex);
    }
}
