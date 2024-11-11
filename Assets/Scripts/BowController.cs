using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BowController : MonoBehaviour
{
    public Camera mainCamera; // ������, ������� ����� �������������� ��� ����������� ���������
    private Vector3 cursorPosition;
    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        // �������� ������� ������� � ������� �����������
        cursorPosition = Input.mousePosition;
        cursorPosition = mainCamera.ScreenToWorldPoint(new Vector3(cursorPosition.x, cursorPosition.y, mainCamera.nearClipPlane));

        // ��������� ������ ����������� �� ���� �� �������
        Vector3 direction = cursorPosition - transform.position;
        direction.z = 0; // ���������� ��� Z, ���� ��� ������ �� ������ ��������� � 3D ������������

        // ��������� ���� ��������
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ��������� ������� � ������� ����
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // -90 ��� �������������, ���� ���������
    }
    
}