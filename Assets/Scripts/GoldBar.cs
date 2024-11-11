using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Player _player;
    public TextMeshProUGUI _text2;
    public void ExpValue(int value)
    {
        _text2.text = value.ToString();

    }

    private void OnEnable()
    {
        _player.MoneyChanged += ExpValue;

    }
    private void OnDisable()
    {
        _player.MoneyChanged -= ExpValue;
    }
}

