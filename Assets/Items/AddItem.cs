using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    public Item _item;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            GridLayoutManager playerInventory = player.GetComponent<GridLayoutManager>();
            playerInventory.AddItem(_item);        
            Destroy(gameObject);            
        }
    }
}
