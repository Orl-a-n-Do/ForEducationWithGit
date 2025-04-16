
using UnityEngine;

public class StandartShooter : IShooter
{
    private int _damage ; //Переменная, которая будет хранить урон, который будет наноситься объекту

    public StandartShooter(int damage) //Конструктор класса Shooter, который будет принимать урон
    {
        _damage = damage; //Присваивание урона переменной _damage
    }
    
    public void Shoot(Vector3 origin, Vector3 direction)
    {
        Ray ray = new Ray(origin, direction); //Создание луча от нуля в сторону вперед
        Debug.Log("Shooter created"); //Вывод в консоль при создании объекта

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
