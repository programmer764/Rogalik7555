
using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private int _reward;     
   
    public delegate void EnemyKilledHandler();
    public static event EnemyKilledHandler OnEnemyKilled;
    public int Money { get; private set; }
    public Transform _target2;    
    public int Reward => _reward;
    public int maxHealth = 100;
    [SerializeField] private float currentHealth = 100;
    public GameObject Exp;    
    private bool Died;
    public Color damageColor = Color.green; // ����, ������� ����� �������������� ��� ��������� �����
    private Color originalColor; // �������� ���� �����
    public bool _cooldown = true;
    public float _timeCooldown=10;



    private SpriteRenderer enemyRenderer; // ������ �� ��������� ����������� �������
    public void PoisonDamage(float duration, float damagePerSecond)
    {
        StartCoroutine(ApplyPoisonDamage(duration, damagePerSecond));
    }

    private IEnumerator ApplyPoisonDamage(float duration, float damagePerSecond)
    {
        float elapsedTime = 0f; // ����� ����� � ������� ������ ����������
        int blinkCount = 1; // ���������� �������

        while (elapsedTime < duration)
        {
            for (int i = 0; i < blinkCount; i++)
            {
                // ������ ���� ����� �� �������
                if (enemyRenderer != null)
                {
                    enemyRenderer.material.color = damageColor;
                }

                // ���� 0.1 �������
                yield return new WaitForSeconds(0.1f);

                // ��������������� �������� ���� �����
                if (enemyRenderer != null)
                {
                    enemyRenderer.material.color = originalColor;
                }

                // ���� ��� 0.1 �������
                yield return new WaitForSeconds(0.1f);
            }

            // ������� ����
            currentHealth -= damagePerSecond;

            // ���������, �� ����� �� ����
            if (currentHealth <= 0)
            {
                Die();
                yield break; // ��������� ��������, ���� ���� �����
            }
            yield return new WaitForSeconds(0.8f);
            // ���� 1 ������� ����� ��������� ����������� �����

            elapsedTime += 1f; // ����������� �����
        }

        // ��������������� �������� ���� ����� ����� ��������� ����������
        if (enemyRenderer != null)
        {
            enemyRenderer.material.color = originalColor;
        }
    }





    void Update()
        {
            try
            {

                if (_target2.position.x > transform.position.x)
                {
                    // ���� ����� ������ �� ����, ��������� ������ ���� ������
                    enemyRenderer.flipX = true;
                }
                else
                {
                    // ���� ����� ����� �� ����, ��������� ������ ���� �����
                    enemyRenderer.flipX = false;
                }
            }
            catch
            {

            }
        }
        void Start()
        {
            enemyRenderer = GetComponent<SpriteRenderer>(); // �������� ��������� SpriteRenderer     
            _target2 = GameObject.FindGameObjectWithTag("Player").transform;
            // ��������� ���������� AIDestinationSetter
            AIDestinationSetter aiDestinationSetter = GetComponent<AIDestinationSetter>();
            // ��������� ������������� ������ � �������� ����
            aiDestinationSetter.target = _target2;
            Died = true;
        // ��������� �������� ���� ��������� �����
        if (enemyRenderer != null)
        {
            originalColor = enemyRenderer.material.color;
        }
    }
    


   
    

    public void TakeDamage(float damageAmount)
    {

        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();

        }
        _cooldown = false;

        IEnumerator DelayedMethod(float delayInSeconds)
        {
            // ��������
            yield return new WaitForSeconds(delayInSeconds);

            // ���, ������� ����� ��������� ����� ��������            
            _cooldown = true;
        }
        StartCoroutine(DelayedMethod(_timeCooldown));
    }
    
   

    void Die()
    {
        if (Died)
        {
            Died = false;
            OnEnemyKilled?.Invoke();
            Destroy(gameObject);
            GameObject xp = Instantiate(Exp, transform.position, transform.rotation);
        }

    }



}
