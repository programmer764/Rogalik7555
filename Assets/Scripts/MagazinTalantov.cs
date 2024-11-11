using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEditor;
using UnityEngine;


public class MagazinTalantov : MonoBehaviour
{
    public GameObject _menu;
    public bool _active;
    public Player _player;
   
    private void Awake()
    {
        
        _active = false;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            ClosePanel();
        }
    }
    public void ClosePanel()
    {
        _menu.SetActive(false);
        _player.canShoot = true; ;
        Time.timeScale = 1;
    }
    public void OpenPanel()
    {
        IEnumerator DelayedMethod(float delayInSeconds)
        {
            // Задержка
            yield return new WaitForSeconds(delayInSeconds);

            // Код, который нужно выполнить после задержки            
            _menu.SetActive(true);
            _player.canShoot = false;
            Time.timeScale = 0;
        }
        StartCoroutine(DelayedMethod(0.3f));
       
    }
    public void OnEnable()
    {        
        _player.LvlUp += OpenPanel;    

    }
    public void OnDisable()
    {
        _player.LvlUp -= OpenPanel;
    }

}
