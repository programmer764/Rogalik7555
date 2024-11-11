using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CircleMov : MonoBehaviour
{
    public float speed = 5f;        // Скорость движения
    public float radius = 5f;       // Радиус круга
    public float damage = 10f;      // Урон
    public Transform centerObject;   // Объект, вокруг которого будет вращаться круг

    private float angle = 0f;        // Угол для вращения
    [SerializeField] private ParticleSystem particleEffect;
         
    void Update()
    {
        // Обновляем угол для кругового движения
        angle += speed * Time.deltaTime;

        if (centerObject != null)
        {
            // Вычисляем новую позицию на круге относительно центрального объекта
            Vector3 newPosition = new Vector3(
                centerObject.position.x + Mathf.Cos(angle) * radius,
                centerObject.position.y + Mathf.Sin(angle) * radius,
                0); // z = 0 для 2D

            transform.position = newPosition; // Обновляем позицию круга
        }

        
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, является ли объект противником
        if (other.CompareTag("Enemy"))
        {
            // Наносим урон противнику
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null  )
            {             
                Instantiate(particleEffect, transform.position, Quaternion.identity);
                enemy.TakeDamage(damage);                     
            }
        }
    }
}

