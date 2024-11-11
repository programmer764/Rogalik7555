using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] public int _damage;


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.ApplyDamage(1);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
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

