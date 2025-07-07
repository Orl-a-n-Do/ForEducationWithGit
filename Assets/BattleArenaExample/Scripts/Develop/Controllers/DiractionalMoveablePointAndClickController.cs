using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DiractionalMoveablePointAndClickController : Controller
{
    private IDirectionalMoveable _moveable; // Интерфейс для управления движением
    private Transform _targetToClick; // Цель для движения
    private NavMeshQueryFilter _queryFilter;
    private NavMeshPath _pathToClick = new NavMeshPath();

    private Vector3 _destination; // Точка назначения
    private bool _hasDestination; // Флаг, указывающий, есть ли цель

    public DiractionalMoveablePointAndClickController(IDirectionalMoveable moveable, Transform targetToClick, NavMeshQueryFilter queryFilter)
    {
        _moveable = moveable;
        _targetToClick = targetToClick;
        _queryFilter = queryFilter;
        _destination = Vector3.zero;
        _hasDestination = false;
    }

    protected override void UpdateLogic(float deltaTime)
    {
       // Проверяем клик мыши
        if (Input.GetMouseButtonDown(0)) // ЛКМ
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Создаем луч из камеры
            if (Physics.Raycast(ray, out RaycastHit hit)) // Проверяем попадание луча
            {
                _destination = hit.point; // Устанавливаем точку назначения
                _hasDestination = true;
            }
        }

        // Если есть цель, двигаем персонажа
        if (_hasDestination)
        {
            Vector3 direction = (_destination - _moveable.Position).normalized; // Направление к цели
            _moveable.SetMoveDirection(direction); // Передаем направление в систему движения

            // Проверяем, достигнута ли цель
            if (Vector3.Distance(_moveable.Position, _destination) < 0.1f)
            {
                _hasDestination = false; // Сбрасываем цель
                _moveable.SetMoveDirection(Vector3.zero); // Останавливаем движение
            }
        }

        _moveable.SetMoveDirection(Vector3.zero);
    }
}
