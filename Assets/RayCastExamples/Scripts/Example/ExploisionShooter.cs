
using UnityEngine;

public class ExploisionShooter : IShooter
{
   private int _damage ; //Переменная, которая будет хранить урон, который будет наноситься объекту
   private float _radius ; //Переменная, которая будет хранить радиус сферы, в которую будет попадать луч

    public ExploisionShooter(int damage, float radius) //Конструктор класса Shooter, который будет принимать урон
    {
        _damage = damage; //Присваивание урона переменной _damage
        _radius = 10f; //Присваивание радиуса сферы переменной _radisus
    }
    
    public void Shoot(Vector3 origin, Vector3 direction)
    {
        Ray ray = new Ray(origin, direction);
        Debug.Log("Shooter created"); //Вывод в консоль при создании объекта

       if(Physics.Raycast(ray, out RaycastHit hit)) //Проверка на попадание луча в объект
        {
            Collider[] targets = Physics.OverlapSphere(hit.point, _radius); //Создание сферы вокруг объекта, в который попал луч

            foreach(Collider target in targets) //Перебор всех объектов, которые попали в сферу
            {
                IDamageable damageable = target.GetComponent<IDamageable>(); //Получение компонента IDamageable из объекта, в который попал луч
                
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
}
