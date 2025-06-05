using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListenerExample : MonoBehaviour
{
   [SerializeField] private EventsExample _example;

   private void Awake()
   {
     _example.HealthChanged += OnHealthChanged;
     
   }

   private void OnHealthChanged(int a)
   {
        Debug.Log("OnEventExample сработал!" + a);
   }

}
