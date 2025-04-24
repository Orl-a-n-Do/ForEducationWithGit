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
            Debug.Log("Правая кнопка мыши нажата");
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
                
                Rigidbody rigidBody = collider.GetComponent<Rigidbody>();
                if (rigidBody != null)
                {
                    
                    Vector3 forceDirection = (rigidBody.position - hit.point).normalized;

                    rigidBody.AddForce(forceDirection * explosionForce, ForceMode.Impulse);
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
