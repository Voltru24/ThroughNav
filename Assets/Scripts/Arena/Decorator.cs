using System.Collections.Generic;
using UnityEngine;

public class Decorator : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private List<GameObject> _decors;

    public void Decorate()
    {
        int indexVoid = -1;
        int index;

        foreach (Transform point in _points)
        {
            index = Random.Range(indexVoid, _decors.Count);

            if (index != indexVoid)
            {
                Instantiate(_decors[index], point);
            }
        }
    }
}
