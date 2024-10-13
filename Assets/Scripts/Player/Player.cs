using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;

    public event Action ChangeHealth;
    public event Action Die;

    public int Health => _health;
    public int MaxHealth => _maxHealth;

    public void TakeDamage(int value)
    {
        _health -= value;
        ChangeHealth?.Invoke();

        if (_health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Die?.Invoke();
        _health = _maxHealth;
    }
}
