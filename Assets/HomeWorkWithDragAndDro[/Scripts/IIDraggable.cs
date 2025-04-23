using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDraggable
{

    void OnDragStart(Vector3 position); // Вызывается при начале перетаскивания
    void OnDrag(Vector3 position);     // Вызывается при перетаскивании
    void OnDragEnd();                  // Вызывается при завершении перетаскивания


}
