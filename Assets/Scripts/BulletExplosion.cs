using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletExplosion : MonoBehaviour
{    
    private Player _player;
    [SerializeField] private ParticleSystem particleEffect;
    public float explosionRadius = 2f;
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {            
            Instantiate(particleEffect, transform.position, Quaternion.identity);
            DamageEnemies(collision.transform.position);
            Destroy(gameObject);
        }

    }
    private void DamageEnemies(Vector2 position)
    {
        // Находим все коллайдеры в области поражения
        Collider2D[] enemies = Physics2D.OverlapCircleAll(position, explosionRadius);

        // Наносим урон врагам в области поражения
        foreach (var enemyCollider in enemies)
        {
            if (enemyCollider.CompareTag("Enemy"))
            {
                Enemy enemy = enemyCollider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(_player._damage);
                }
            }
        }

        // Опционально: добавить визуальный эффект или звук взрыва
        // Например, Instantiate(explosionEffect, position, Quaternion.identity);
    }


private void Start()
    {

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        // Получаем текущий слой у пули
        int bulletLayer = LayerMask.NameToLayer("Bullet");

        // Настройка слоя игнорирования коллизий между объектами с одинаковым слоем
        Physics2D.IgnoreLayerCollision(bulletLayer, bulletLayer);
        IEnumerator DelayedMethod(float delayInSeconds)
        {
            // Задержка
            yield return new WaitForSeconds(delayInSeconds);

            // Код, который нужно выполнить после задержки
            Destroy(gameObject);

        }
        StartCoroutine(DelayedMethod(1f));

    }
}



