using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPlayer : MonoBehaviour
{
   

    private IAttacker _attacker;


    public void SetShooter(IAttacker attacker)
    {
        _attacker = attacker;
    }

    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            _attacker.Shoot();

        }
    }

}
