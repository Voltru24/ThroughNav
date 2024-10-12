using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private Transform _healthBars;
    [SerializeField] private EnemyHealthBar _healthBar;

    public List<Enemy> Spawn()
    {
        List<Enemy> enemies = new List<Enemy>();

        int indexVoid = -1;
        int index;
        Enemy enemy;
        EnemyHealthBar healthBar;

        foreach (Transform point in _points)
        {
            index = Random.Range(indexVoid, _enemies.Count);

            if (index != indexVoid)
            {
                enemy = Instantiate(_enemies[index], point);

                healthBar = Instantiate(_healthBar, _healthBars);

                healthBar.SetEnemy(enemy);

                enemies.Add(enemy);
            }
        }

        return enemies;
    }
}
