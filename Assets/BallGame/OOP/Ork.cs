using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ork : MonoBehaviour
{
    public Ork(string name, int health, int damage)
    {
        Name = name;
        Health = health;
        Damage= damage;
    }




    public string Name {get;}
    public int Health {get; protected set;}
    public int Damage {get; protected set;}

    
    public virtual void TakeDamage(int damage)
    {
        
        if(damage < 0)
        {
            Debug.LogError("damage < 0");
            return;
        }
         Health -= damage;

        if(Health <= 0)
        {
            Health = 0;
            Debug.Log($"О нет, я, {Name},умер!");    
        }

    }

    public abstract void IssueCry();
    
}
