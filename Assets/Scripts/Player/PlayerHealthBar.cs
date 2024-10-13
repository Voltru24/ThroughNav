using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        Show();
    }

    private void OnEnable()
    {
        _player.ChangeHealth += Show;
    }

    private void OnDisable()
    {
        _player.ChangeHealth -= Show;
    }

    private void Show()
    {
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _player.Health;
    }
}
