using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<float, float> Changed;

    public Health(float current, float max)
    {
        Current = current;
        Max = max;
    }

    public float Max { get; }
    public float Current { get; private set; }

    public void Reduce(float value)
    {
        if (value < 0)
        {
            Debug.LogError(nameof(value));
            return;
        }
        float oldValue = Current;

        Current = Mathf.Clamp(Current - value, 0, Max);
        Changed?.Invoke(oldValue, Current);
    }
    
    public void Add(float value)
    {
        if (value < 0)
        {
            Debug.LogError(nameof(value));
            return;
        }

        float oldValue = Current;

        Current = Mathf.Clamp(Current + value, 0, Max);
        Changed?.Invoke(oldValue, Current);
    }

}
