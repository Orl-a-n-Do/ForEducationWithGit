using UnityEngine;

public class ValueChanger : MonoBehaviour
{
    [SerializeField] private ReactiveVariable _reactiveVariable;
    [SerializeField] private int _incrementAmount = 1;
    
    private void Update()
    {
        // Увеличиваем значение при нажатии на пробел
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncrementValue();
        }
        
        // Уменьшаем значение при нажатии на клавишу R
        if (Input.GetKeyDown(KeyCode.R))
        {
            DecrementValue();
        }
        
        // Сбрасываем значение при нажатии на клавишу C
        if (Input.GetKeyDown(KeyCode.C))
        {
            ResetValue();
        }
    }
    
    public void IncrementValue()
    {
        if (_reactiveVariable != null)
        {
            _reactiveVariable.Value += _incrementAmount;
        }
    }
    
    public void DecrementValue()
    {
        if (_reactiveVariable != null)
        {
            _reactiveVariable.Value -= _incrementAmount;
        }
    }
    
    public void ResetValue()
    {
        if (_reactiveVariable != null)
        {
            _reactiveVariable.Value = 0;
        }
    }
}