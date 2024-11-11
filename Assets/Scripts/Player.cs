using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;




public class Player : MonoBehaviour
{          
    public int _flatHp;
    public int _exp;
    public int _maxExp;
    public float _damage;
    public float _flatSpeed; 
    public float _flatDamage;
    public float _percentDamage;
    public int _gold;
    public int levelHero;
    public int talantPoints;

    public  UnityAction <int> HealthChanged;    
    public UnityAction<int> MoneyChanged;
    public UnityAction<int,int> ExpChanged;
    public UnityAction<int> ManaChanged;
    public UnityAction LvlUp;
    public List<GameObject> _listTranform;
    public GameObject _centerObject;
    public Stats _knigaStats;
    public int _levelTalants;
    
    public bool canShoot;
    
    public Transform _transform;
    public Vector2 _position;
    public int Money { get; private set; }
    public void Start()
    {
        canShoot = true;
        _damage = 10;
        levelHero = 0;
        _position =gameObject.transform.position;        
    }   
    public void RenderStats ()
    {       
        HealthChanged?.Invoke(_flatHp);
    }
    public void ApplyDamage(int damage)
    {

        _flatHp -= damage;
        HealthChanged?.Invoke(_flatHp);
        if (_flatHp <= 0)
            Destroy(gameObject);
    }   
   
    public GameObject CheckPoints()
    {
        foreach (GameObject go in _listTranform)
        {
            if (go.transform.childCount > 0)
            {
                Debug.Log("Точка занята: " );                
            }
            else if (go.transform.childCount == 0)
            {
                Debug.Log("Точка свободна: ");
                return go;

            }
        }
        return null;
    }

  

    public void AddExp(int exp)
    {        
        _exp += exp; 
        ExpChanged?.Invoke(_exp,_maxExp);
    }
    public void AddGold(int gold)
    {
        _gold += gold; 
        MoneyChanged?.Invoke(_gold);
    }
    public void LvlUpppp()
    { 
        LvlUp?.Invoke();
    }

}
       




