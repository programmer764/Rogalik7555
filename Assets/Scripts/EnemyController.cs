using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    private Transform player; // ������ �� ������
    private Rigidbody2D rb; // Rigidbody2D ����
    public float speed = 5f; // �������� ������������ ����

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // ����� ������ �� ����
        rb = GetComponent<Rigidbody2D>(); // �������� ��������� Rigidbody2D
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized; // ����������� � ������
            rb.velocity = direction * speed; // ������������ � ����������� ������
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ��������� ������������ � �������
            Debug.Log("Enemy collided with Player");
        }
    }
}
