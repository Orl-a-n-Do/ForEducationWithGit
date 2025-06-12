using UnityEngine;
using UnityEngine.UI;

public class ValueListener : MonoBehaviour
{
    [SerializeField] private ReactiveVariable _reactiveVariable;
    [SerializeField] private Text _valueText;
    
    private void Start()
    {
        if (_reactiveVariable != null)
        {
            // Подписываемся на событие Changed
            _reactiveVariable.Changed += OnValueChanged;
            
            // Обновляем текст с текущим значением
            UpdateText(_reactiveVariable.Value);
        }
        else
        {
            Debug.LogError("ReactiveVariable reference is missing!", this);
        }
    }
    
    private void OnDestroy()
    {
        if (_reactiveVariable != null)
        {
            // Отписываемся от события при уничтожении объекта
            _reactiveVariable.Changed -= OnValueChanged;
        }
    }
    
    private void OnValueChanged(int oldValue, int newValue)
    {
        Debug.Log($"Value changed from {oldValue} to {newValue}");
        UpdateText(newValue);
    }
    
    private void UpdateText(int value)
    {
        if (_valueText != null)
        {
            _valueText.text = $"Value: {value}";
        }
    }
}