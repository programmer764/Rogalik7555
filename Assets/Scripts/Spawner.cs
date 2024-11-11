using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public float spawnRate = 2f;   
    private float nextSpawnTime = 0f;
    private int x; private float spawnX; private float spawnY;

    void Update()
    {
        
            if (Time.time > nextSpawnTime)
            {

                Camera mainCamera = Camera.main;
                x = Random.Range(1, 5);
                switch (x)
                {
                    case 1:
                        {
                            spawnX = Random.Range(0, mainCamera.pixelWidth);
                            spawnY = Random.Range(mainCamera.pixelHeight + 100, mainCamera.pixelHeight + 100);
                            break;
                        }
                    case 2:
                        {
                            spawnX = Random.Range(0, mainCamera.pixelWidth);
                            spawnY = Random.Range(-100, -100);
                            break;
                        }
                    case 3:
                        {
                            spawnX = Random.Range(-100, -100);
                            spawnY = Random.Range(0, mainCamera.pixelHeight);
                            break;
                        }
                    case 4:
                        {
                            spawnX = Random.Range(mainCamera.pixelWidth + 100, mainCamera.pixelWidth + 100);
                            spawnY = Random.Range(0, mainCamera.pixelHeight);
                            break;
                        }
                }
            
            
        


            Vector2 spawnPosition = mainCamera.ScreenToWorldPoint(new Vector2(spawnX, spawnY));

            // Проверяем, что моб не пересекается с другими объектами
            bool canSpawn = true;
            Collider[] hitColliders = Physics.OverlapSphere(spawnPosition, 1.0f); // Радиус проверки области наличия других объектов
            foreach (Collider col in hitColliders)
            {
                if (col.gameObject.tag == "Enemy")
                {
                    canSpawn = false;
                    break;
                }
            }

            if (canSpawn)
            {
                int y =Random.Range(0, 2);
                switch(y)
                {
                    case 0:
                        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(enemyPrefab2, spawnPosition, Quaternion.identity);
                        break;

                }                
            }

            nextSpawnTime = Time.time + spawnRate;
        }
    }
}

