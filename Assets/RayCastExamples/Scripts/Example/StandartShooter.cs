
using UnityEngine;

public class StandartShooter : IShooter
{
    private int _damage ; //Переменная, которая будет хранить урон, который будет наноситься объекту

    public StandartShooter(int damage) //Конструктор класса Shooter, который будет принимать урон
    {
        _damage = damage; //Присваивание урона переменной _damage
    }
    
    public void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Создание луча из камеры в точку на экране, куда мы нажали мышкой

        if(Physics.Raycast(ray, out RaycastHit hit)) //Проверка на попадание луча в объект
        {
            IDamageable damageable = hit.collider.GetComponent<IDamageable>(); //Получение компонента IDamageable из объекта, в который попал луч

            if(damageable != null) //Проверка на наличие компонента IDamageable в объекте
            {
                damageable.TakeDamage(_damage); //Вызов метода TakeDamage у объекта, в который попал луч
            }
            else
            {
                Debug.Log("No damageable component found"); //Вывод в консоль, если компонент IDamageable не найден
            }
        }


    }

   
}
