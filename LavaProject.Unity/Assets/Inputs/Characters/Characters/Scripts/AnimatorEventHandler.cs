using System;
using System.Collections;
using System.Collections.Generic;
using Inputs.Characters.Scripts;
using UnityEngine;

public class AnimatorEventHandler : MonoBehaviour
{
    public event Action onJumpEndEvent;
    public Animator PlayerAnimator;
    private SaidController _saidController;

    private void Start()
    {
        _saidController = GetComponentInParent<SaidController>();
        _saidController.OnJump += AnimateJump;
    }

    public void OnJumpEnd()
    {
        onJumpEndEvent?.Invoke();
    }

    public void AnimateJump()
    {
        PlayerAnimator.SetTrigger("Jump");
        _saidController.IsJump = false;
    }
}
