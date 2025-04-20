using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Player : MonoBehaviour
{
    private IShooter _shooter; //Переменная, которая будет хранить объект Shooter
   
    public void SetShooter(IShooter shooter) //Метод, который будет принимать объект Shooter
    {
        _shooter = shooter; //Присваиваем переменной Shooter объект Shooter
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Если нажата клавиша Space
        {
            _shooter.Shoot(); //Вызываем метод Shoot у объекта Shooter
        }
    }
    
}
