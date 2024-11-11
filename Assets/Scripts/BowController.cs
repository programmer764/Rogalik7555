using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BowController : MonoBehaviour
{
    public Camera mainCamera; // Камера, которая будет использоваться для конвертации координат
    private Vector3 cursorPosition;
    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        // Получаем позицию курсора в мировых координатах
        cursorPosition = Input.mousePosition;
        cursorPosition = mainCamera.ScreenToWorldPoint(new Vector3(cursorPosition.x, cursorPosition.y, mainCamera.nearClipPlane));

        // Вычисляем вектор направления от лука до курсора
        Vector3 direction = cursorPosition - transform.position;
        direction.z = 0; // Игнорируем ось Z, если ваш объект не должен вращаться в 3D пространстве

        // Вычисляем угол поворота
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Применяем поворот к объекту лука
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // -90 для корректировки, если требуется
    }
    
}