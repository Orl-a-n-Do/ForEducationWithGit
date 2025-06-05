using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EventsExample : MonoBehaviour
{
    public event Action<int> HealthChanged;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            HealthChanged?.Invoke(10);
    }


}

