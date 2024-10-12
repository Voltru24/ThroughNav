using System;
using UnityEngine;

public class EnemyScanner : MonoBehaviour
{
    public event Action FoundPlayer;
    public event Action LostPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            FoundPlayer?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            LostPlayer?.Invoke();
        }
    } 
}
