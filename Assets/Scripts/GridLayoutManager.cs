using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class GridLayoutManager : MonoBehaviour
{
    public GameObject _GridLayout; 
    public GameObject prefabCell;
    public GameObject parentObject;
    public List<Item> inventoryitems;
    public Player _player;
    GameObject go2;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public void AddItem(Item item)
    {
        GameObject newItem;
        newItem = Instantiate(prefabCell, transform.position, transform.rotation);
        Image image = newItem.GetComponent<Image>();
        image.sprite = item.icon;
        newItem.transform.SetParent(_GridLayout.transform);
        newItem.transform.localScale = new Vector2(transform.localScale.x *1/2 , transform.localScale.y * 1/2 );
        newItem.GetComponent<IPointerDownHandler>();
        DragAndDrop drag = newItem.GetComponent<DragAndDrop>();
        drag.item = item;
        inventoryitems.Add(item); 
        if (item.goMechanics != null )
        {
            GameObject go = _player.CheckPoints();
            if (go != null)
            {
                drag._go = Instantiate(item.goMechanics, go.transform.position, Quaternion.identity);
                drag._go.transform.SetParent(go.transform);
            }
        }
        if (item.goMechanics2 != null)
        {
            GameObject go = _player._centerObject;
            if (go != null)
            {
                drag._go2 = Instantiate(item.goMechanics2, go.transform.position, Quaternion.identity);
                drag._go2.transform.SetParent(go.transform);
            }
        }
        if (item.haveStats)
        {
            _player._damage += item.damage;
            _player._flatHp += item.maxHp;
            _player._flatSpeed += item.speed;
        }
        _player.RenderStats();
    }    

    public void RemoveItem(Item item)
    {
        inventoryitems.Remove(item); 
        if (item.haveStats)
        {
            _player._damage -= item.damage;
            _player._flatHp -= item.maxHp;
            _player._flatSpeed -= item.speed;
        }
        _player.RenderStats();
    }
   

}