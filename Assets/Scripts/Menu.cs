using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    public GameObject _menu;public GameObject _menuDeath;
    public void OpenPanel()
    {
        _menu.SetActive(true);
        Time.timeScale = 0;
    }
    private void Start()
    {
        
    }
    public void ClosePanel()
    {
        _menu.SetActive(false);
        Time.timeScale = 1;
        _player.canShoot = true;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void OnEnable()
    {      
        TargetDiePosition.Dying += DeathScreen;
    }
    public void DeathScreen()
    {
        _menuDeath.SetActive(true);
        Time.timeScale = 0;        
    }
    public void OnDisable() 
    {
        TargetDiePosition.Dying -= DeathScreen;
    }


    public void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {            
                OpenPanel();              
                        
        }
}
   

}
