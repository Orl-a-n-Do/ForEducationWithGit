using System;
using UnityEngine;

public class MainHero : MonoBehaviour, IDamageable
{
    private int _health = 100;

    

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new System.ArgumentOutOfRangeException(nameof(damage), "Damage must be non-negative");


        _health -= damage; 

        if (_health < 0)
            _health = 0;

        Debug.Log($"Сharacter health: {_health}");

    }


}
