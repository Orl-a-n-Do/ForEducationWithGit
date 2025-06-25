using System;
using UnityEngine;

public class Wallet
{
    public event Action<int, int> Changed;

    public Wallet(int maxValue)
    {
        MaxValue = maxValue;
        if (maxValue < 0)
        {
            Debug.LogError(nameof(maxValue));
            return;
        }
        MaxValue = maxValue;
    }

    // Автосвойство только для чтения
    public int Value { get; private set; }

    // Обычный метод
    public int MaxValue { get; private set; }



    public bool IsEnoughSpace(int value) => Value + value <= MaxValue;

    public void TryAdd(int value)
    {
        if (value < 0)
        {
            Debug.LogError(nameof(value));
            return;
        }

        if (IsEnoughSpace(value) == false)
        {
            Debug.LogError("Not enough space");
            return;
        }

        Value += value;

        Changed?.Invoke(Value, MaxValue);
    }
    

}
