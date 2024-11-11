using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExpBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    public TextMeshProUGUI _text2;
    public void ExpValue(int value,int maxvalue)
    {
        _text2.text = value.ToString();

    }

    private void OnEnable()
    {
        _player.ExpChanged += ExpValue;

    }
    private void OnDisable()
    {
        _player.ExpChanged -= ExpValue;
    }
}

