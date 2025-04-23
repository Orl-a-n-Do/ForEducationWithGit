using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public Camera mainCamera; 
    public GameObject explosionEffectPrefab; 
    public float explosionRadius = 5f; 
    public float explosionForce = 10f; 

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            HandleExplosion();
        }
    }

    private void HandleExplosion()
    {
        
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            
            if (explosionEffectPrefab != null)
            {
                Instantiate(explosionEffectPrefab, hit.point, Quaternion.identity);
            }

            
            Collider[] colliders = Physics.OverlapSphere(hit.point, explosionRadius);

            foreach (var collider in colliders)
            {
                
                Rigidbody rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    
                    Vector3 forceDirection = (rb.position - hit.point).normalized;

                    rb.AddForce(forceDirection * explosionForce, ForceMode.Impulse);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
