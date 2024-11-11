using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public GameObject circlePrefab; // ������ �����
    public int circleCount = 10;     // ����� ���������� ������
    public float radius = 5f;         // ������, �� ������� ����� ������������� �����
    public float speed = 5f;          // �������� �������� ������

    private GameObject[] circles;     // ������ ��� �������� ������

    void Start()
    {
        circles = new GameObject[circleCount];

        for (int i = 0; i < circleCount; i++)
        {
            // ������������ ���� ��� ������� �����
            float angle = i * Mathf.PI * 2 / circleCount; // 2? * ������ = ������ ����
            Vector3 position = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
            circles[i] = Instantiate(circlePrefab, position, Quaternion.identity);
            circles[i].transform.SetParent(transform); // ��������� ��������, ����� ��� ��������� ������ � ���� ��������
        }
    }

    void Update()
    {
        // ��������� �������� ������
        for (int i = 0; i < circles.Length; i++)
        {
            float angle = Time.time * speed + (i * Mathf.PI * 2 / circleCount); // �������� �� ����
            Vector3 position = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
            circles[i].transform.localPosition = position; // ������������� ����� ������� ��� �����
        }
    }
}
