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
        float offset = 1.0f; // ������ �� ��������� ������

        // ������ ������������ �������� ������ �� ��������� ������
        Vector3 spawnerPosition = new Vector3(Random.Range(-bounds.x, bounds.x), // X ���������� � �������� ������ ������
            bounds.y + offset, // Y ���������� �� ������� �������� ������
            0
        );

        // �������� ��������
        Instantiate(spawnerPrefab, spawnerPosition, Quaternion.identity);
    }
   
    IEnumerator DelayedMethod(float delayInSeconds)
    {
        for (int i = 0; i < 20; i++)
        {
            // ��������
            yield return new WaitForSeconds(delayInSeconds);

            // ���, ������� ����� ��������� ����� ��������
            PlaceSpawnersOutsideScreen();
        }
    }    

    // ����� ��������
    void Start()
    {
        // ������ �������� � ��������� � 5 ������
        StartCoroutine(DelayedMethod(1f));
    }
    private void Update()
    {
       
    }



}
