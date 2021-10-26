using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CelebvrationState : State
{
    private Animator _animator;
    private string _animatorCelebration = "Celebration";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        
    }

    private void OnEnable()
    {
        _animator.Play(_animatorCelebration);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
