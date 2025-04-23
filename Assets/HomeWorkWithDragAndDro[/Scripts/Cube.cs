using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IDraggable
{
    private Vector3 offset;


    public void OnDragStart(Vector3 position)
    {
        offset = transform.position - position;
    }

    public void OnDrag(Vector3 position)
    {
        transform.position = position + offset;
    }

    public void OnDragEnd()
    {
        // Дополнительная логика при завершении перетаскивания (если нужно)
    }
}
