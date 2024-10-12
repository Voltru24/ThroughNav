using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Decorator))]
[RequireComponent(typeof(SpawnerEnemies))]
public class Arena : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private Player _player;

    private Decorator _decorator;
    private SpawnerEnemies _spawnerEnemies;

    private void Start()
    {
        _decorator = GetComponent<Decorator>();
        _spawnerEnemies = GetComponent<SpawnerEnemies>();

        _decorator.Decorate();
        _enemies = _spawnerEnemies.Spawn();

        foreach (Enemy enemy in _enemies)
        {
            enemy.SetTarget(_player.transform);

            enemy.Run();
        }
    }
}
