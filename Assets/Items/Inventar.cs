using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Inventar : MonoBehaviour
{
    public GameObject GridLayout; // ссылка на LayoutGrid
    public GameObject lol;
    //public List<Item> inventoryitems = new List<Item>();
    
    private int l;
    private void Start()
    {       
        
    }
    public void AddItem(Item item)
    {

        
       // GameObject newItem;
       // inventoryitems.Add(item);
       // newItem = Instantiate(lol, transform.position, transform.rotation);       
       // Image image = newItem.GetComponent<Image>();        
       // image.sprite = item.icon;
       //// newItem.transform.SetParent(GridLayout.transform);        
       // newItem.transform.localScale = new Vector2(transform.localScale.x * 1 / 4, transform.localScale.y * 1 / 4);       
        //newItem.tag="del";
       // DragAndDrop _dr= newItem.GetComponent < DragAndDrop >();        
       // newItem.GetComponent<IPointerDownHandler>();
        //item.inventoryGrid = gameObject;
       // Debug.Log(""+ inventoryitems.Count);
       // l++;
       // item.inventoryGrid = gameObject;
       // newItem.name = l.ToString();
              
               
    }


    public void RemoveItem(Item item)
    {
        
       
    }
    

}
