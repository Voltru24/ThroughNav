using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int _forceAttack = 1;
    [SerializeField] private float _speedAttack = 2f;

    private List<Enemy> _enemies = new List<Enemy>();
    private bool isAttackTimer = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            if(_enemies.Contains(enemy))
            {
                return;
            }

            _enemies.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            _enemies.Remove(collision.GetComponent<Enemy>());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isAttackTimer == false)
            {
                Attack();

                Invoke(nameof(AttackTimer), _speedAttack);

                isAttackTimer = true;
            }
        }
    }


    private void Attack()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.TakeDamage(_forceAttack, transform, 10);
        }
    }

    private void AttackTimer()
    {
        isAttackTimer = false;
    }
}
