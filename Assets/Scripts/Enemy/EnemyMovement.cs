using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rigidbody;
    private Transform _transform;

    private Coroutine _moving;

    public event Action<Vector2> ChangePosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = transform;
    }

    private void Update()
    {
        ChangePosition?.Invoke(_rigidbody.position);
    }

    public void Move(Transform target)
    {
        if (target == null)
        {
            return;
        }

        _moving = StartCoroutine(Moving(target));
    }

    public void Stop()
    {
        if (_moving == null)
        {
            return;
        }

        StopCoroutine(_moving);

        _moving = null;
    }

    private IEnumerator Moving(Transform target)
    {
        bool isWork = true;

        WaitForFixedUpdate wait = new WaitForFixedUpdate();

        Vector3 direction;

        while (isWork)
        {
            if (target != null)
            {
                direction = (target.position - transform.position).normalized;

                Rotate(direction.x);

                _rigidbody.AddForce(_moveSpeed * direction);
            }

            yield return wait;
        }
    }

    private void Rotate(float horizontal)
    {
        int degreeReversal;

        if (horizontal < 0)
        {
            degreeReversal = 0;
        }
        else
        {
            degreeReversal = 180;
        }

        _transform.rotation = Quaternion.Euler(Vector2.up * degreeReversal);
    }
}
