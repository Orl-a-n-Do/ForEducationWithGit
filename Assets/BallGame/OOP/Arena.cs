using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{   
    void Start()
    {     
        OrkPaladin orkPaladin = new OrkPaladin(10, 3,"ОркПаладин", 35, 2);
        OrkMage orkMage = new OrkMage(2,"Орк-Маг", 35, 2);


        ShowInfoAbout(orkPaladin);
        ShowInfoAbout(orkMage);

        orkPaladin.IssueCry();
        orkMage.IssueCry();
        //ProcessBattle(orkMage, orkPaladin);
        //DetermineWinner(orkMage, orkPaladin);
    }

    private void ShowInfoAbout(Ork ork)
    {

        Debug.Log($"Имя: {ork.Name}, хп {ork.Health}");
        ork.IssueCry();

    }



    private void ProcessBattle(OrkMage orkMage, OrkPaladin orkPaladin)
    {
        while(orkMage.Health > 0 && orkPaladin.Health > 0 )
        {
            orkMage.CastSpell();
            orkPaladin.TakeDamage(orkMage.Damage);

            orkPaladin.Heal();
           // orkMage.TakeDamage(orkPaladin.Damage);

            Debug.Log($"{orkPaladin.Name} -{orkPaladin.Health}");
            Debug.Log($"{orkMage.Name} -{orkMage.Health}");

        }

    }

    private void DetermineWinner(OrkMage orkMage, OrkPaladin orkPaladin)
    {
        if(orkMage.Health < 0 && orkPaladin.Health < 0)
        {
            Debug.Log("Ничья");
        }
        else if(orkMage.Health > 0)
            Debug.Log($"Победил{orkMage.Name}");
        else
            Debug.Log($"Победил {orkPaladin.Name}");    
    }

}
