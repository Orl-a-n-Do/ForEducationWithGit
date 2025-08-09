using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonoDestroyable : MonoBehaviour // Этот класс наследуют все обьекты которым нормально надо обрабатвывать метод Destroy
{

    public event Action<MonoDestroyable> Destroyed;

    public bool IsDestroyed { get; private set; }


    public void Destroy()
    {
        Destroy(gameObject);

        IsDestroyed = true;
        
        Destroyed?.Invoke(this);
    }



}
