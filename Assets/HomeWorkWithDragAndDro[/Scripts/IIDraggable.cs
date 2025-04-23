using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDraggable
{

    void OnDragStart(Vector3 position); // ���������� ��� ������ ��������������
    void OnDrag(Vector3 position);     // ���������� ��� ��������������
    void OnDragEnd();                  // ���������� ��� ���������� ��������������


}
