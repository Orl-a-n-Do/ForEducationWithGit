using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterSwitcher : MonoBehaviour
{
    [SerializeField] private Player _player; //Переменная, которая будет хранить объект Player
    

    private void Awake()
    {
        _player.SetShooter(new StandartShooter(10)); //Передача объекта Shooter в объект Player
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) //Проверка нажатия клавиши 1
        {
            _player.SetShooter(new StandartShooter(10)); //Передача объекта Shooter в объект Player
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) //Проверка нажатия клавиши 2
        {
            _player.SetShooter(new ExploisionShooter(20, 15)); //Передача объекта Shooter в объект Player
        }
       
    }



}
