using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : IShootEffect
{
    private int _damage; //Переменная, которая будет хранить урон

    public DamageEffect(int damage) //Конструктор класса DamageEffect, который будет принимать урон
    {
        _damage = damage; //Присваивание урона переменной _damage
    }


    public void Execute(Vector3 point, Collider collider)
    {
        IDamageable damageable = collider.GetComponent<IDamageable>(); //Получение компонента IDamageable из объекта, в который попал луч

        if(damageable != null) //Проверка на наличие компонента IDamageable в объекте
            {
                damageable.TakeDamage(_damage); //Вызов метода TakeDamage у объекта, в который попал луч
            }
    }
}

