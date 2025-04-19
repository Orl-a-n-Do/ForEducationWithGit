using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

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
        _dragAndDrop.Update();

        if (Input.GetMouseButtonDown(1)) //Проверка нажатия левой кнопки мыши
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Создание луча от камеры в сторону мыши
            _shooter.Shoot(ray.origin, ray.direction); //Создание объекта Shooter
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Создание луча от камеры в сторону мыши

            if (Physics.Raycast(ray, out RaycastHit hit)) //Проверка на попадание луча в объект
            {
                IPickable pickable = hit.collider.GetComponent<IPickable>(); //Получение компонента IPickable из объекта, в который попал луч

                if (pickable != null) //Проверка на наличие компонента IDamageable в объекте
                {
                    _dragAndDrop.PickUpObject(pickable.Rigidbody);
                }
                else
                {
                    Debug.Log("No IPickable component found"); //Вывод в консоль, если компонент IPickable не найден
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _dragAndDrop.DropObject();
        }
    }
}
