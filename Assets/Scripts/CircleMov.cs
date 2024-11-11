using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CircleMov : MonoBehaviour
{
    public float speed = 5f;        // �������� ��������
    public float radius = 5f;       // ������ �����
    public float damage = 10f;      // ����
    public Transform centerObject;   // ������, ������ �������� ����� ��������� ����

    private float angle = 0f;        // ���� ��� ��������
    [SerializeField] private ParticleSystem particleEffect;
         
    void Update()
    {
        // ��������� ���� ��� ��������� ��������
        angle += speed * Time.deltaTime;

        if (centerObject != null)
        {
            // ��������� ����� ������� �� ����� ������������ ������������ �������
            Vector3 newPosition = new Vector3(
                centerObject.position.x + Mathf.Cos(angle) * radius,
                centerObject.position.y + Mathf.Sin(angle) * radius,
                0); // z = 0 ��� 2D

            transform.position = newPosition; // ��������� ������� �����
        }

        
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ���������, �������� �� ������ �����������
        if (other.CompareTag("Enemy"))
        {
            // ������� ���� ����������
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null  )
            {             
                Instantiate(particleEffect, transform.position, Quaternion.identity);
                enemy.TakeDamage(damage);                     
            }
        }
    }
}

