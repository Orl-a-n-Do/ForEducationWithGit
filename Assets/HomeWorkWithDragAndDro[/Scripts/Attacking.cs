
using UnityEngine;

public class Attacking 
{
    
    private int _damage;
   
    public Attacking(int damage) 
    {
        _damage = damage;
    }
   


    public void Attack()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();

            if(damageable != null)
                damageable.TakeDamage(_damage);
        }
    }

}
