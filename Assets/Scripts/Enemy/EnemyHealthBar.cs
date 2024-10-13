using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private float _heightSlider;

    private Slider _slider;

    private Enemy _enemy;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;

        _slider = GetComponent<Slider>();
    }

    public void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;

        _enemy.Movement.ChangePosition += ChangePosition;
        _enemy.ChangeHealth += Show;
        _enemy.Die += Hide;

        ChangePosition(_enemy.gameObject.transform.position);
        Show();
    }

    private void Show()
    {
        _slider.maxValue = _enemy.MaxHealth;
        _slider.value = _enemy.Health;
    }

    private void Hide(Enemy _)
    {
        Destroy(gameObject);
    }

    private void ChangePosition(Vector2 position)
    {
        _transform.position = position + Vector2.up * _heightSlider;
    }
}
