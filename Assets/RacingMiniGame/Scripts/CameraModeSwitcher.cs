using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraModeSwitcher : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> _cameras; //Список камер

    private Queue<CinemachineVirtualCamera> _camerasQueue; //Очередь камер

    private void Awake()
    {
        _camerasQueue = new Queue<CinemachineVirtualCamera>(_cameras); //Инициализация очереди камер
    }

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.C)) //Проверка нажатия клавиши C
        {
            SwitchNextMode();
        }
    }

    

    private void SwitchNextMode()
    {
        CinemachineVirtualCamera nextMode = _camerasQueue.Dequeue(); //Извлечение первой камеры из очереди
        foreach (var item in _cameras) //Перебор всех камер в очереди
        {
            item.gameObject.SetActive(false); //Выключение камеры
        }

        nextMode.gameObject.SetActive(true); //Включение следующей камеры
        _camerasQueue.Enqueue(nextMode); //Добавление камеры в конец очереди
    }
}
