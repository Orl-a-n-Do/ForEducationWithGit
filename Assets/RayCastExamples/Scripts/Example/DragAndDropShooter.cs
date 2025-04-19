using UnityEngine;

public class DragAndDropShooter : IDragAndDrop
{
    private float _moveSpeed;
    private Rigidbody _heldObject; // Ссылка на поднятый объект
    
    public DragAndDropShooter(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }

    public void Update()
    {
        if (_heldObject == null)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if (Physics.Raycast(ray, out RaycastHit hit, 0, new LayerMask(ground?))) //Проверка на попадание луча в объект

        if (Physics.Raycast(ray, out RaycastHit hit)) //Проверка на попадание луча в объект
        {
            Vector3 targetPosition = hit.transform.position;

            _heldObject.transform.position = Vector3.Lerp(
                _heldObject.transform.position, 
                targetPosition, 
                    _moveSpeed * Time.deltaTime);
        }
    }

    public void PickUpObject(Rigidbody obj)
    {
        _heldObject = obj; // Сохраняем ссылку на объект
        _heldObject.isKinematic = true; // Отключаем физику

        Debug.Log($"Поднятый обьект: {_heldObject.name}");
    }

    public void DropObject()
    {
        if (_heldObject != null)
        {
            _heldObject.isKinematic = false; // Включаем физику
            _heldObject.transform.SetParent(null); // Убираем родителя
            Debug.Log($"Dropped object: {_heldObject.name}");
            _heldObject = null; // Очищаем ссылку на объект
        }
    }
}
