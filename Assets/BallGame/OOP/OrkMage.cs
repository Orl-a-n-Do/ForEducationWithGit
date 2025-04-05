using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrkMage : Ork
{
    
    private int _damageMultiplier;

    public OrkMage(int damageMultiplier , string name, int health, int damage): base(name, health, damage)
    {
        _damageMultiplier = damageMultiplier;
    }


    public void CastSpell()
    {
        Debug.Log("Я использую способнсотоь");
        Damage *= _damageMultiplier;
    }

    public override void IssueCry()
    {
        throw new System.NotImplementedException();
    }
}
