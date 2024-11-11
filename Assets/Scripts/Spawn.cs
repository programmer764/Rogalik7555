using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject spawnerPrefab;
   
    Vector2 GetCameraBounds()
    {
        Camera mainCamera = Camera.main;
        Vector2 screenBounds = new Vector2(mainCamera.ViewportToWorldPoint(new Vector3(1, 0, mainCamera.nearClipPlane)).x, mainCamera.ViewportToWorldPoint(new Vector3(0, 1, mainCamera.nearClipPlane)).y);
        return screenBounds;
    }
    public void PlaceSpawnersOutsideScreen()
    {
        Vector2 bounds = GetCameraBounds();
        float offset = 1.0f; // Отступ за пределами экрана

        // Пример расположения спавнера сверху за пределами экрана
        Vector3 spawnerPosition = new Vector3(Random.Range(-bounds.x, bounds.x), // X координата в пределах ширины экрана
            bounds.y + offset, // Y координата за верхней границей экрана
            0
        );

        // Создание спавнера
        Instantiate(spawnerPrefab, spawnerPosition, Quaternion.identity);
    }
   
    IEnumerator DelayedMethod(float delayInSeconds)
    {
        for (int i = 0; i < 20; i++)
        {
            // Задержка
            yield return new WaitForSeconds(delayInSeconds);

            // Код, который нужно выполнить после задержки
            PlaceSpawnersOutsideScreen();
        }
    }    

    // Вызов корутины
    void Start()
    {
        // Запуск корутины с задержкой в 5 секунд
        StartCoroutine(DelayedMethod(1f));
    }
    private void Update()
    {
       
    }



}
