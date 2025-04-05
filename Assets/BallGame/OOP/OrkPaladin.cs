using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrkPaladin : Ork
{
    
    private int _additiveHealth;
    private int _armor ;


    public OrkPaladin(int additiveHealth,int armor, string name, int health, int damage): base(name, health, damage)
    {
        _additiveHealth = additiveHealth;
    }

    public override void TakeDamage(int damage)
    {
        damage -= _armor;

        if(damage < 0)
            damage = 0;

        base.TakeDamage(damage);
    }


    public void Heal()
    {
        Debug.Log("Я использую лечение");
        Health += _additiveHealth;
    }

    public override void IssueCry()
    {
        throw new System.NotImplementedException();
    }

}
