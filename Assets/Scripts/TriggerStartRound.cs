using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStartRound : MonoBehaviour
{
    [SerializeField] private Arena _arena;
    [SerializeField] private Village _village;
    [SerializeField] private CameraMovement _camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _camera.Stop();
            player.gameObject.transform.position = Vector3.zero;
            _village.gameObject.SetActive(false);
            _arena.gameObject.SetActive(true);
            _arena.NextLevel();
        }
    }
}
