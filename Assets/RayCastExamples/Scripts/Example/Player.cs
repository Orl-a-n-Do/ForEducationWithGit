using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IShooter _shooter; //Переменная, которая будет хранить объект Shooter
    private IDragAndDrop _dragAndDrop; //Переменная, которая будет хранить объект DragAndDrop

    
    public void SetShooter(IShooter shooter) 
    {
        _shooter = shooter; 
    }
    public void SetDragAndDrop(IDragAndDrop dragAndDrop) //Метод, который будет передавать объект DragAndDrop в объект Player
    {
        _dragAndDrop = dragAndDrop; //Передача объекта DragAndDrop в объект Shooter
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
