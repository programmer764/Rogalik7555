using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    private Transform player; // Ссылка на игрока
    private Rigidbody2D rb; // Rigidbody2D моба
    public float speed = 5f; // Скорость передвижения моба

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Найти игрока по тегу
        rb = GetComponent<Rigidbody2D>(); // Получить компонент Rigidbody2D
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized; // Направление к игроку
            rb.velocity = direction * speed; // Передвижение в направлении игрока
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Обработка столкновения с игроком
            Debug.Log("Enemy collided with Player");
        }
    }
}
