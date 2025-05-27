using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListenerExample : MonoBehaviour
{
   [SerializeField] private EventsExample _example;


   private void Awake()
   {

        _example.EventExample += OnEventExample;


   }

   private void OnEventExample()
   {
        Debug.Log("OnEventExample сработал!");
   }
}
