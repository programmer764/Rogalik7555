using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CelebrationState : State
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    
}
