using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������, ���������� �� ������� ������ � �������� � ����� "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);

            // �������� ����� ���, ������� �� ������ ��������� ��� ������������ � �������
        }
    }
    
}
