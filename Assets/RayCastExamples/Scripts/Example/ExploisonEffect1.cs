using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploisonEffect : IShootEffect
{
    private DamageEffect _damage; 
    private float _radius; 
    

    public ExploisonEffect(DamageEffect damage, float radius) //Конструктор класса DamageEffect, который будет принимать урон
    {
        _damage = damage; //Присваивание урона переменной _damage
        _radius = 5f; //Присваивание радиуса взрыва переменной _radius
    }


    public void Execute(Vector3 point, Collider collider)
    {
        Collider[] targets = Physics.OverlapSphere(point, _radius); //Создание сферы вокруг объекта, в который попал луч

        foreach(Collider target in targets) //Перебор всех объектов, которые попали в сферу
        {
           _damage.Execute(target.transform.position, target); //Вызов метода Execute у объекта, в который попал луч
        }
    }
}

