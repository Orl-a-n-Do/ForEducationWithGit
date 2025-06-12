using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage<T> where T : MonoBehaviour
{
    private List<T> _apples = new List<T>();


    public T GetRandom() => _apples[Random.Range(0, _apples.Count)];
    public Vector3 GetRandomEntityPosition() => GetRandom().transform.position;

    public void Add(T apple)
    {
        if (_apples.Contains(apple))
        {
            Debug.Log($"{nameof(apple)} is already exist");
            return;

        }

        _apples.Add(apple);
    }


    public void Remove(T apple)
    {
        if (_apples.Contains(apple) == false)
        {
            Debug.Log($"{nameof(apple)} is not exist");
            return;

        }
        _apples.Remove(apple);
    }
    

    

}
