using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthExample : MonoBehaviour
{
    [SerializeField] private HealthView _healthView;
    private Health _health;

    private void Awake()
    {
        _health = new Health(100, 100);

        _healthView.Initialize(_health);

        _health.Changed += OnHealthChanged;
    }

    private void OnDestroy()
    {
        _health.Changed -= OnHealthChanged;
    }

    private void OnHealthChanged(float arg1, float newValue)
    {
        if (newValue <= 0)
            Debug.Log("Потрачено");     
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _health.Reduce(10);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _health.Add(10);
        }
    }
}
