using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyAttack))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    [SerializeField] private EnemyScanner _scanner;
    [SerializeField] private EnemyAttack _attack;

    private EnemyMovement _movement;
    private Transform _target;
    private Rigidbody2D _rigidbody;

    public event Action ChangeHealth;
    public event Action<Enemy> Die;

    public int Health => _health;
    public int MaxHealth => _maxHealth;

    public EnemyMovement Movement => _movement;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _movement = GetComponent<EnemyMovement>();
        _attack = GetComponent<EnemyAttack>();
    }

    private void OnEnable()
    {
        _scanner.LostPlayer += Run;
        _scanner.LostPlayer += _attack.Attack;
        _scanner.FoundPlayer += _movement.Stop;
    }

    private void OnDisable()
    {
        _scanner.LostPlayer -= Run;
        _scanner.LostPlayer -= _attack.Attack;
        _scanner.FoundPlayer -= _movement.Stop;
    }

    public void TakeDamage(int value)
    {
        _health -= value;

        if (_health <= 0)
        {
            Kill();
        }
    }

    public void TakeDamage(int value, Transform attacker, float force)
    {
        Vector3 direction = -(attacker.position - transform.position).normalized;

        _health -= value;
        ChangeHealth?.Invoke();

        _rigidbody.AddForce(direction * force, ForceMode2D.Impulse);

        if (_health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Die?.Invoke(this);
        Destroy(gameObject);
    }

    public void Run()
    {
        _movement.Move(_target);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
