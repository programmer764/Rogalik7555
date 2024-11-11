using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Guns : MonoBehaviour
{
    [SerializeField] private Transform hitPoint;
    [SerializeField] protected bool _shoot;
    [SerializeField] private GameObject bulletPrefab;
    protected Vector3 direction;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Animator _animator;
    [SerializeField] private float detectionRadius = 10f; // Радиус обнаружения цели
    [SerializeField] private float  _attackSpeed;
    void Start()
    {
        
        // Вы можете инициализировать что-то здесь, если нужно
    }

    void Update()
    {
        
    }

    protected void Shoot()
    {        
        if (_shoot)
        {
            _animator.Play("Bow");
            _shoot = false;

            IEnumerator DelayedMethod(float delayInSeconds)
            {
                yield return new WaitForSeconds(delayInSeconds);

                // Создание пули
                GameObject bullet = Instantiate(bulletPrefab, hitPoint.position, hitPoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = direction * bulletSpeed; // Устанавливаем скорость пули
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
                bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                _shoot = true; // Разрешаем следующую атаку
            }
            StartCoroutine(DelayedMethod(_attackSpeed));
        }
    }
    protected  void ShootDrobovik()
    {

        if (_shoot)
        {
            _animator.Play("Bow");
            _shoot = false;
            IEnumerator DelayedMethod(float delayInSeconds)
            {
                yield return new WaitForSeconds(delayInSeconds);

                // Создание пули
                for (int i = 0; i < 10; i++)
                {
                    float angle2 = UnityEngine.Random.Range(-35f, 35f);//генерация угла для дробовика
                    GameObject bullet = Instantiate(bulletPrefab, hitPoint.position, hitPoint.rotation);//создание префаба пули в текущем месте выстрела
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();//получение риджетбоди с префаба пули
                    rb.velocity = Quaternion.AngleAxis(angle2, Vector3.forward) * direction * bulletSpeed;//движение пули под рандомным углом в текущем направлении игрока
                    float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;//вычисление угла префаба в зависимости от направления пули
                    bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);//задание направления угла префаба

                }
                _shoot = true; // Разрешаем следующую атаку
            }
            StartCoroutine(DelayedMethod(_attackSpeed));
        }
        for (int i = 0; i < 10; i++)
        {
            float angle2 = UnityEngine.Random.Range(-35f, 35f);//генерация угла для дробовика
            GameObject bullet = Instantiate(bulletPrefab, hitPoint.position, hitPoint.rotation);//создание префаба пули в текущем месте выстрела
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();//получение риджетбоди с префаба пули
            rb.velocity = Quaternion.AngleAxis(angle2, Vector3.forward) * direction * bulletSpeed;//движение пули под рандомным углом в текущем направлении игрока
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;//вычисление угла префаба в зависимости от направления пули
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);//задание направления угла префаба

        }
    }

    protected GameObject FindNearestEnemy()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        GameObject closestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Enemy")) // Проверьте, если тег "Enemy"
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = collider.gameObject;
                }
            }
        }

        return closestEnemy; // Возвращаем ближайшего врага
    }
}
