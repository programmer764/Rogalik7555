using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    public TextMeshProUGUI _text;
    public void OnValueChanged(int value)
    {
        _text.text = value.ToString();


    }

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;

    }
    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }
}
