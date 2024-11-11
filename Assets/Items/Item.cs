using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Goods", menuName = "Goods", order = 51)]

public class Item: ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public string description;
    public GameObject itemPrefab;
    public GameObject goMechanics;
    public GameObject goMechanics2;
    public bool haveStats;
    public int damage;
    public int maxHp;
    public int speed;
   

}
