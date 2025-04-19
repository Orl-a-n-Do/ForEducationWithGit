
using UnityEngine;

public class DragAndDropShooter : IDragAndDrop
{
   private int _damage ; //Переменная, которая будет хранить урон, который будет наноситься объекту
   private float _radius ; //Переменная, которая будет хранить радиус сферы, в которую будет попадать луч
   private Transform _heldObject; // Ссылка на поднятый объект
    private Transform _holdPoint; // Точка, где объект будет удерживаться


    public DragAndDropShooter(int damage, float radius, Transform holdPoint)
    {
        _damage = damage;
        _radius = radius;
        _holdPoint = holdPoint; // Устанавливаем точку удержания
    }


    public void PickUpObject(Transform obj)
    {
        _heldObject = obj; // Сохраняем ссылку на объект
        _heldObject.GetComponent<Rigidbody>().isKinematic = true; // Отключаем физику
        _heldObject.SetParent(_holdPoint); // Делаем объект дочерним точке удержания
        _heldObject.localPosition = Vector3.zero; // Ставим объект в центр точки удержания
        Debug.Log($"Поднятый обьект: {_heldObject.name}");
    }

    public void DropObject()
    {
        if (_heldObject != null)
        {
            _heldObject.GetComponent<Rigidbody>().isKinematic = false; // Включаем физику
            _heldObject.SetParent(null); // Убираем родителя
            Debug.Log($"Dropped object: {_heldObject.name}");
            _heldObject = null; // Очищаем ссылку на объект
        }
    }
    
    public void Shoot(Vector3 origin, Vector3 direction)
    {
        Ray ray = new Ray(origin, direction);
        Debug.Log("Shooter created"); //Вывод в консоль при создании объекта

       if (Physics.Raycast(ray, out RaycastHit hit)) // Проверка на попадание луча в объект
        {
            Collider[] targets = Physics.OverlapSphere(hit.point, _radius); // Создание сферы вокруг объекта, в который попал луч

            foreach (Collider target in targets) // Перебор всех объектов, которые попали в сферу
            {
                IDamageable damageable = target.GetComponent<IDamageable>(); // Получение компонента IDamageable из объекта
                if (damageable != null) // Проверка на наличие компонента IDamageable
                {
                    // Если объект еще не поднят
                    if (_heldObject == null && Input.GetMouseButtonDown(0)) // ЛКМ нажата
                    {
                        PickUpObject(target.transform); // Поднимаем объект
                    }
                    // Если объект уже поднят
                    else if (_heldObject != null && Input.GetMouseButtonUp(0)) // ЛКМ отпущена
                    {
                        DropObject(); // Отпускаем объект
                    }
                }
                else
                {
                    Debug.Log("No damageable component found"); // Вывод в консоль, если компонент IDamageable не найден
                }
            }
        }

    }

}
