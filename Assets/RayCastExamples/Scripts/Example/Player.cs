using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IShooter _shooter; //Переменная, которая будет хранить объект Shooter

    
    public void SetShooter(IShooter shooter) 
    {
        _shooter = shooter; 
    }



    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Проверка нажатия левой кнопки мыши
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Создание луча от камеры в сторону мыши
            _shooter.Shoot(ray.origin, ray.direction); //Создание объекта Shooter
        }
    }

}
