using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, столкнулся ли текущий объект с объектом с тегом "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);

            // Добавьте здесь код, который вы хотите выполнить при столкновении с игроком
        }
    }
    
}
