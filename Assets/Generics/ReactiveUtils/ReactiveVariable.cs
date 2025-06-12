using System;
using UnityEngine;

public class ReactiveVariable : MonoBehaviour
{
    /// <summary>
    /// Событие, вызываемое при изменении значения переменной.
    /// Передает старое и новое значение.
    /// </summary>
    public event Action<int, int> Changed;

    // Текущее значение переменной.
    private int _value;

    /// <summary>
    /// Конструктор по умолчанию. Устанавливает значение по умолчанию (0).
    /// </summary>
    public ReactiveVariable() => _value = default(int);

    /// <summary>
    /// Конструктор с параметром. Устанавливает начальное значение переменной.
    /// </summary>
    /// <param name="value">Начальное значение</param>
    public ReactiveVariable(int value) => _value = value;
    
    /// <summary>
    /// Свойство для доступа и изменения значения переменной.
    /// При изменении вызывает событие Changed.
    /// </summary>
    public int Value
    {
        get => _value;
        set
        {
            int oldValue = _value;

            _value = value;

            // Если значение изменилось, уведомить подписчиков.
            if (_value != oldValue)
                Changed?.Invoke(oldValue, _value);
        }
    }
}
