using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



public class SliderExp : MonoBehaviour
{
    [SerializeField] protected Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] protected TextMeshProUGUI _text;
    public ParticleSystem _particleEffect;
    public ParticleSystem _particleEffect2;
    private ParticleSystem go1;
    private ParticleSystem go2;
    public int i,j,k;
    [SerializeField] TextMeshProUGUI _textTalantPoints;

    private void Start()
    {
        _slider =gameObject.GetComponent<Slider>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public void Render()
    {

        _textTalantPoints.text = _player.talantPoints.ToString();
        tmp_speed.text = _player._flatSpeed.ToString();
        tmp_damage.text = _player._damage.ToString();
        tmp_maxphp.text = _player._flatHp.ToString();
        
    }
    public void OnValueChanged (int value, int maxValue)
    {



        while (_player._exp > _player._maxExp)
        {
            _player._exp = _player._exp - _player._maxExp;
            _player.levelHero++;

            _player.talantPoints++;
            _player._maxExp = _player._maxExp + 5;
            _text.text = _player.levelHero.ToString();
            go1 = Instantiate(_particleEffect, _player.transform.position, Quaternion.Euler(-90, 0, 0));         
            go2 = Instantiate(_particleEffect2, _player.transform.position, Quaternion.identity);
            _player.LvlUpppp();
            
        }
        _slider.value =(float) _player._exp / _player._maxExp;
        Render();
    }
    private void OnEnable()
    {
        _player.ExpChanged += OnValueChanged;
        
    }
    private void OnDisable()
    {
        _player.ExpChanged -= OnValueChanged;
    }
       
    
    [SerializeField] private TextMeshProUGUI tmp_damage;
    [SerializeField] private TextMeshProUGUI tmp_attack_speed;
    [SerializeField] private TextMeshProUGUI tmp_speed;
    [SerializeField] private TextMeshProUGUI tmp_maxphp;
    
    
}
