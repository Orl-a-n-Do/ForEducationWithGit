using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void MyDelegate();

public class EventsExample : MonoBehaviour
{
   public event MyDelegate EventExample;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            EventExample?.Invoke();

    }



}
