using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private bool _isMovening;
    [SerializeField] private float _distance;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;

        if (_isMovening)
        {
            ChangePosition(player.gameObject.transform.position);
        }
    }

    private void OnEnable()
    {
        player.ChangePosition += ChangePosition;
    }

    private void OnDisable()
    {
        player.ChangePosition -= ChangePosition;
    }

    public void Stop()
    {
        ChangePosition(Vector2.zero);
        _isMovening = false;
    }

    public void Run()
    {
        ChangePosition(player.gameObject.transform.position);
        _isMovening = true;
    }


    private void ChangePosition(Vector2 position)
    {
        if (_isMovening)
        {
            _transform.position = position;
            _transform.position += Vector3.forward * _distance;
        }
    }
}
