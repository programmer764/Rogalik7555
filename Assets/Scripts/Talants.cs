using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

using Button = UnityEngine.UI.Button;

public class Talants : MonoBehaviour
{
    private Player _player;
    public TextMeshProUGUI _text2;
    public bool isBuyed;   
    private Button button1;
    public int _levelSpell;
    public string descriptionText;
    public TextMeshProUGUI descriptionUI;
    public ParticleSystem _particleEffect;
    public ParticleSystem go;
    public GameObject panel;
    [SerializeField] TextMeshProUGUI _textTalantPoints;
    [SerializeField] TextMeshProUGUI _lvlTalants;
    [SerializeField] private SliderExp _sliderExp;
    public void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        isBuyed = false;       
        button1 = gameObject.GetComponent<Button>();
        _player._levelTalants = 0;
    }
    public void BuyTalant()
    {
        if (!isBuyed)
        {
            if (_levelSpell < 5)
            {
                
                go = Instantiate(_particleEffect, gameObject.transform.position, Quaternion.identity);
                go.transform.SetParent(panel.transform);                
                _levelSpell++;
                _player._levelTalants++;
                _player.ExpChanged?.Invoke(_player._exp,_player._maxExp);
                _player.talantPoints--;             
                _textTalantPoints.text = _player.talantPoints.ToString();
                _lvlTalants.text =  _levelSpell.ToString()+"/5";                
                if (_levelSpell > 4)
                {
                    isBuyed = true;
                    
                }
            }
        }
    }
   
    public void AddHpMaxHP()
    {
        
        if (!isBuyed && _player.talantPoints > 0)
        {
           
            BuyTalant();
            _player._flatHp += 10;
            _player.HealthChanged?.Invoke(_player._flatHp);
            _sliderExp.Render();

        }
    }
    public void AddDamage()
    {
        if (!isBuyed && _player._exp > 9 && _player._levelTalants > 4)
        {
            BuyTalant();
            _player._damage += 10;

        }
    }
    public void AddSpeed()
    {
        if (!isBuyed && _player._exp > 9 && _player._levelTalants > 9)
        {
            BuyTalant();
            _player._flatSpeed += 0.5f;
        }
    }



         public void OnMouseEnter()
        {
       
            descriptionUI.gameObject.SetActive(true);
            descriptionUI.text = descriptionText;
            
        }

         public void OnMouseExit()
        {
            descriptionUI.gameObject.SetActive(false);
        }
    
}




