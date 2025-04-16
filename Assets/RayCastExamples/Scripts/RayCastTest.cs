using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{

    private void Update()
    {
        Ray ray = new Ray(Vector3.zero, Vector3.forward);
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition); //Промежуточный объект, который будет хранить луч от камеры до объекта

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Debug.Log("Hit: " + hitInfo.collider.name);
        }
        else
        {
            Debug.Log("No hit");
        }

        Physics.Raycast(ray);
        
        Collider[] colliders = Physics.OverlapSphere(Vector3.zero,10); //Промежуточный объект, который будет хранить луч от камеры до объекта
        Physics.OverlapSphereNonAlloc(Vector3.zero, 10, colliders); //Промежуточный объект, который будет хранить луч от камеры до объекта
    }

    private void OnDrawGizmos() //Постояная отрисовка
    {
        if(Application.isPlaying)
        {
            Gizmos.color = Color.red;
            // Gizmos.DrawRay(Vector3.zero, Vector3.forward * 10f);

            // Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition); //Промежуточный объект, который будет хранить луч от камеры до объекта
            // Gizmos.DrawRay(cameraRay.origin, cameraRay.direction * 100f); //Отрисов

            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(mouseWorldPosition, 1f); //Отрисовка сферы в месте попадания луча
            Gizmos.DrawRay(mouseWorldPosition, Camera.main.transform.forward * 100f); //Отрисовка луча от сферы в сторону камеры
        }

    }

    // private void OnDrawGizmosSelected() //только если выделен объект на кот висит этот скрипт
    // {
    //     Gizmos.color = Color.green;
    //     Gizmos.DrawRay(Vector3.zero, Vector3.forward * 100);
    // }
    

}
