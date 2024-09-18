using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private Player _player;


    private void Start()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.SetTarget(_player.transform);

            enemy.Run();
        }
    }

}
