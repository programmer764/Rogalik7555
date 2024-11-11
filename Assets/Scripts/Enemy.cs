
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
    public Color damageColor = Color.green; // Цвет, который будет использоваться при получении урона
    private Color originalColor; // Исходный цвет врага
    public bool _cooldown = true;
    public float _timeCooldown=10;



    private SpriteRenderer enemyRenderer; // Ссылка на компонент отображения спрайта
    public void PoisonDamage(float duration, float damagePerSecond)
    {
        StartCoroutine(ApplyPoisonDamage(duration, damagePerSecond));
    }

    private IEnumerator ApplyPoisonDamage(float duration, float damagePerSecond)
    {
        float elapsedTime = 0f; // Общее время с момента начала отравления
        int blinkCount = 1; // Количество миганий

        while (elapsedTime < duration)
        {
            for (int i = 0; i < blinkCount; i++)
            {
                // Меняем цвет врага на зеленый
                if (enemyRenderer != null)
                {
                    enemyRenderer.material.color = damageColor;
                }

                // Ждем 0.1 секунды
                yield return new WaitForSeconds(0.1f);

                // Восстанавливаем исходный цвет врага
                if (enemyRenderer != null)
                {
                    enemyRenderer.material.color = originalColor;
                }

                // Ждем еще 0.1 секунды
                yield return new WaitForSeconds(0.1f);
            }

            // Наносим урон
            currentHealth -= damagePerSecond;

            // Проверяем, не мертв ли враг
            if (currentHealth <= 0)
            {
                Die();
                yield break; // Завершаем корутину, если враг мертв
            }
            yield return new WaitForSeconds(0.8f);
            // Ждем 1 секунду перед следующим применением урона

            elapsedTime += 1f; // Увеличиваем время
        }

        // Восстанавливаем исходный цвет врага после окончания отравления
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
                    // Если игрок справа от моба, повернуть спрайт моба вправо
                    enemyRenderer.flipX = true;
                }
                else
                {
                    // Если игрок слева от моба, повернуть спрайт моба влево
                    enemyRenderer.flipX = false;
                }
            }
            catch
            {

            }
        }
        void Start()
        {
            enemyRenderer = GetComponent<SpriteRenderer>(); // Получаем компонент SpriteRenderer     
            _target2 = GameObject.FindGameObjectWithTag("Player").transform;
            // Получение компонента AIDestinationSetter
            AIDestinationSetter aiDestinationSetter = GetComponent<AIDestinationSetter>();
            // Установка трансформации игрока в качестве цели
            aiDestinationSetter.target = _target2;
            Died = true;
        // Сохраняем исходный цвет материала врага
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
            // Задержка
            yield return new WaitForSeconds(delayInSeconds);

            // Код, который нужно выполнить после задержки            
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
