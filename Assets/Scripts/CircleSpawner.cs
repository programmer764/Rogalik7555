using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public GameObject circlePrefab; // Префаб круга
    public int circleCount = 10;     // Общее количество кругов
    public float radius = 5f;         // Радиус, на котором будут располагаться круги
    public float speed = 5f;          // Скорость движения кругов

    private GameObject[] circles;     // Массив для хранения кругов

    void Start()
    {
        circles = new GameObject[circleCount];

        for (int i = 0; i < circleCount; i++)
        {
            // Рассчитываем угол для каждого круга
            float angle = i * Mathf.PI * 2 / circleCount; // 2? * радиус = полный круг
            Vector3 position = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
            circles[i] = Instantiate(circlePrefab, position, Quaternion.identity);
            circles[i].transform.SetParent(transform); // Установим родителя, чтобы они двигались вместе с этим объектом
        }
    }

    void Update()
    {
        // Обновляем движение кругов
        for (int i = 0; i < circles.Length; i++)
        {
            float angle = Time.time * speed + (i * Mathf.PI * 2 / circleCount); // Смещение по углу
            Vector3 position = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
            circles[i].transform.localPosition = position; // Устанавливаем новую позицию для круга
        }
    }
}
