using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackRangeState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _lastAttackTime;
    private Animator _animator;
    public GameObject _bulletPrefab;
    public float bulletSpeed;

    private void Start()
    {
        _animator = GetComponent<Animator>();

    }
    private void Update()
    {

        

    
        if (_lastAttackTime <= 0 && Target != null)
        {
            IEnumerator DelayedMethod(float delayInSeconds)
            {
                // Задержка
                yield return new WaitForSeconds(delayInSeconds);

                // Код, который нужно выполнить после задержки
                Attack(Target);
            }
            StartCoroutine(DelayedMethod(0.5f));            
            _lastAttackTime = _delay;
            _animator.Play("demon93-100");
            if (Target == null)
                Debug.Log("Target = null");
        }
        _lastAttackTime -= Time.deltaTime;

    }
    private void Attack(Player target)
    {
        GameObject bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector3 shootDirection = Target.transform.position - transform.position;
        rb.velocity = shootDirection * bulletSpeed;        
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);    
    }

}
