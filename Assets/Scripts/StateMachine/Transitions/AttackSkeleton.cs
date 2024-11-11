using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackSkeleton : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _lastAttackTime;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

    }
    private void Update()
    {
        if (_lastAttackTime <= 0 && Target != null)
        {
            Attack(Target);
            _lastAttackTime = _delay;
            if (Target == null)
                Debug.Log("Target = null");
        }
        _lastAttackTime -= Time.deltaTime;
    }
    private void Attack(Player target)
    {
        _animator.Play("AttackSkeleton");
        target.ApplyDamage(_damage);
    }
}
