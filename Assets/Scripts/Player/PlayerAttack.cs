using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int _forceAttack = 1;
    [SerializeField] private float _speedAttack = 2f;
    [SerializeField] private float _sphereCastRadius;
    [SerializeField] private float _spherCastDistance;

    private bool isAttackTimer = false;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
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
        Vector2 direction;

        if (_transform.rotation.y == 0)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        RaycastHit2D[] hits = Physics2D.CircleCastAll(_transform.position, _sphereCastRadius, direction, _spherCastDistance);

        Debug.Log(hits.Length);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(_forceAttack, _transform, 10);
            }
        }
    }

    private void AttackTimer()
    {
        isAttackTimer = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Vector3 direction;

        if (transform.rotation.y == 0)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        Gizmos.DrawSphere(transform.position + direction * _spherCastDistance , _sphereCastRadius);
    }
}
