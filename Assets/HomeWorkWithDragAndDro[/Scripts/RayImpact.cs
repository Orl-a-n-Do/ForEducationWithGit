using System.Collections.Generic;
using UnityEngine;

public class RayImpact :MonoBehaviour
{
    public float impactRadius = 5f; 
    public float forceMagnitude = 10f; 

    public void HandleDragging()
    {
        throw new System.NotImplementedException();
    }

    
    public void Shoot(Vector3 origin, Vector3 direction)
    {
        Ray ray = new Ray(origin, direction);
        RaycastHit hit;

        
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log($"Ray hit: {hit.collider.name}");

            
            Collider[] colliders = Physics.OverlapSphere(hit.point, impactRadius);

            foreach (var collider in colliders)
            {
                Rigidbody rb = collider.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    
                    Vector3 forceDirection = (collider.transform.position - hit.point).normalized;

                    
                    rb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
                }
            }
        }
    } 
}