using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Decorator))]
[RequireComponent(typeof(SpawnerEnemies))]
public class Arena : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Village _village;
    [SerializeField] private Transform _respawn;
    [SerializeField] private CameraMovement _cameraMovement;

    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    private bool isRun = false;
    
    private Decorator _decorator;
    private SpawnerEnemies _spawnerEnemies;

    private void Awake()
    {
        _decorator = GetComponent<Decorator>();
        _spawnerEnemies = GetComponent<SpawnerEnemies>();
    }

    private void OnEnable()
    {
        _player.Die += Exit;
    }

    private void OnDisable()
    {
        _player.Die -= Exit;
    }

    public void NextLevel()
    {
        isRun = true;
        _decorator.Decorate();
        _enemies = _spawnerEnemies.Spawn();

        foreach (Enemy enemy in _enemies)
        {
            enemy.SetTarget(_player.transform);
            enemy.Die += DieEnemy;
            enemy.Run();
        }
    }

    private void DieEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);

        if (_enemies.Count == 0 && isRun)
        {
            NextLevel();
        }
    }

    private void Exit()
    {
        isRun = false;

        _village.gameObject.SetActive(true);

        for (int i = _enemies.Count - 1; i >= 0; i--)
        {
            Debug.Log(i);
            _enemies[i].Kill();
        }

        _player.gameObject.transform.position = _respawn.position;

        _cameraMovement.Run();
        gameObject.SetActive(false);
    }
}
