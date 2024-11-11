using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chest : MonoBehaviour
{
    public GameObject Exp;
    public Animator animator;
    // Start is called before the first frame update
    public bool _opened;
    public List<Item> inventoryitems = new List<Item>();
    void Start()
    {
        
        _opened = false;
        
    }
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_opened)
        {
            if (collision.gameObject.TryGetComponent(out Player player))
            {                
                animator.Play("New Animation");                
                
                _opened = true;
                IEnumerator DelayedMethod(float delayInSeconds)
                {
                    // Задержка
                    yield return new WaitForSeconds(delayInSeconds);

                    // Код, который нужно выполнить после задержки
                    foreach (Item items in inventoryitems)
                    {
                        float spawnX; float spawnY;
                        spawnX = transform.position.x+ Random.Range(-1f,1f);
                        spawnY = transform.position.y+ Random.Range(-1f,1f);                        
                        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
                        GameObject xp = Instantiate(items.itemPrefab, spawnPosition, transform.rotation);
                    }
                }
                StartCoroutine(DelayedMethod(1f));

            }
        }
    }
}
