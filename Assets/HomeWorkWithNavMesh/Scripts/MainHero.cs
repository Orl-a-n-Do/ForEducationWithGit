using System;
using UnityEngine;
using UnityEngine.UI;

public class MainHero : MonoBehaviour, IDamageable
{
    private int _health = 100;
    private int _maxHealth = 100;

    public int Health => _health;

    [SerializeField] private Image _healthBarImage;

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new System.ArgumentOutOfRangeException(nameof(damage), "Damage must be non-negative");


        _health -= damage;

        if (_health < 0)
            _health = 0;

        Debug.Log($"Сharacter health: {_health}");

        if (_health == 0)
            Debug.Log("MainHero is DEAD!");


        UpdateHealthBar();
        if (_health == 0)
            Debug.Log("MainHero is DEAD!");

    }
    

    private void UpdateHealthBar()
    {
        if (_healthBarImage != null)
            _healthBarImage.fillAmount = (float)_health / _maxHealth;
    }


}
