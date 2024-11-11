using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropMenuItem : MonoBehaviour
{
    public Dropdown dropdownMenu;

    void Start()
    {
         // Начинаем с скрытым меню
    }

    public void ShowDropdownMenu()
    {
        dropdownMenu.gameObject.SetActive(true);
    }

    public void HideDropdownMenu()
    {
        dropdownMenu.gameObject.SetActive(false);
    }
    
        public  void OnMouseEnter()
        {
        Debug.Log("==");
            ShowDropdownMenu();

        }
        void OnMouseExit()
        {
            HideDropdownMenu();

        }


    
}
