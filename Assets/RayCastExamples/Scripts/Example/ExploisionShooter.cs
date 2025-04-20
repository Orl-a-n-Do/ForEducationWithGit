
using UnityEngine;

public class ExploisionShooter : IShooter
{
    private int _damage ; //Переменная, которая будет хранить урон, который будет наноситься объекту
    private float _radius;

    public ExploisionShooter(int damage, float radius) //Конструктор класса Shooter, который будет принимать урон
    {
        _damage = damage; //Присваивание урона переменной _damage
    }
    
    public void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Создание луча из камеры в точку на экране, куда мы нажали мышкой

        if(Physics.Raycast(ray, out RaycastHit hit)) //Проверка на попадание луча в объект
        {
            Collider[] targets = Physics.OverlapSphere(hit.point, _radius); // Получаем все коллайдеры в радиусе 5 единиц от точки попадания

            foreach(Collider target in targets) // Проходим по всем коллайдерам
            {
                IDamageable damageable = target.GetComponent<IDamageable>(); //Получение компонента IDamageable из объекта, в который попал луч

                if(damageable != null) //Проверка на наличие компонента IDamageable в объекте
                {
                    damageable.TakeDamage(_damage); //Вызов метода TakeDamage у объекта, в который попал луч
                }       
            }
        }
    }

}

