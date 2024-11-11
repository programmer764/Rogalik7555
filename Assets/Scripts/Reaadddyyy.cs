using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Debug = UnityEngine.Debug;

public class Reaadddyyy : MonoBehaviour
{  
    [SerializeField] private  GameObject _spawn;
    [SerializeField] private GameObject _yes;
    [SerializeField] private GameObject _wall;  
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private BoxCollider2D box;

    public int i,j;
    // Start is called before the first frame update
    private void Start()
    {
        Enemy.OnEnemyKilled += EndWave;
        i = 30;j = i / 2;
    }
    private void OnDestroy()
    {
        // Отписываемся от события, чтобы избежать утечек памяти
        Enemy.OnEnemyKilled -= EndWave;
    }
    public void SpawnActivate()
    {
        box.enabled = false;
        _spawn.SetActive(true);
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Player lol = player.GetComponent<Player>();
            _yes.SetActive(false);
            audioSource.Play();
            SpawnActivate();
            IEnumerator DelayedMethod(float delayInSeconds)
            {
                // Задержка
                yield return new WaitForSeconds(delayInSeconds);

                // Код, который нужно выполнить после задержки

                _spawn.SetActive(false);
            }
            StartCoroutine(DelayedMethod(i));
        }
    }

    void EndWave()
    {        
        j--;
        
        if (j == 0)
        {
            i = i + 10;
            j = i / 2;
            
            _yes.SetActive(true);
            box.enabled = true;
            audioSource.Pause();
            Destroy(_wall);

        }
    }
   

   


}
