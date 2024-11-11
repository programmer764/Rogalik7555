using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Gun", menuName = "Gun", order = 51)]
public class Gun : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public string description;
    public GameObject itemPrefab;
    public int baseDamage;
    public int baseAttackSpeed;

}