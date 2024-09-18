using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rigidbody2d;
    private Animator _animator;
    private Transform _transform;

    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _transform = transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0) 
        {
            _animator.SetBool(PlayerAnimatorData.Params.isRun, true);

            Rotate(horizontal);

            _rigidbody2d.AddForce(_moveSpeed * Vector2.right * horizontal);
            _rigidbody2d.AddForce(_moveSpeed * Vector2.up * vertical);
        }
        else
        {
            _animator.SetBool(PlayerAnimatorData.Params.isRun, false);
        }
    }

    private void Rotate(float horizontal) 
    {
        int degreeReversal;

        if (horizontal < 0)
        {
             degreeReversal = 180;
        }
        else
        {
            degreeReversal = 0;
        }

        _transform.rotation = Quaternion.Euler(Vector2.up * degreeReversal);
    }
}
