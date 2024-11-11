using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class MoveSkeleton : State
    {
        private Animator _animator;
        private void Start()
        {
        
            _animator = GetComponent<Animator>();
        }
        private void Update()
        {
            if (Target == null)
                return;
            _animator.Play("WalkSkeleton");

        }
    }

