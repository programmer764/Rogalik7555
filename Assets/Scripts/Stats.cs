using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public GameObject _menu;
    public bool _active;
    private Player _player;
    [SerializeField] private TextMeshProUGUI tmp_damage;
    [SerializeField] private TextMeshProUGUI tmp_attack_speed;
    [SerializeField] private TextMeshProUGUI tmp_speed;
    [SerializeField] private TextMeshProUGUI tmp_maxphp;
    private void Start()
    {
        _active = false;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Render();

    }
    public void Render()
    {
        tmp_speed.text = _player._flatSpeed.ToString();
        tmp_damage.text = _player._damage.ToString();
        tmp_maxphp.text = _player._flatHp.ToString();
    }
      
    
   
}
