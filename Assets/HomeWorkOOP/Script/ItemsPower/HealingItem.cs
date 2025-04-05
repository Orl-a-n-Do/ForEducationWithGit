using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HealingItem : Items
{
    [SerializeField] private int _healAmount;
    [SerializeField] private ParticleSystem _healingEffect;

    public override int Value => _healAmount;

    public override void PlayParticleEffect()
    {
        if (_healingEffect != null)
        {
            // Создаем партикл-эффект в позиции предмета
            ParticleSystem effect = Instantiate(_healingEffect, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration); 
        }
    }

    public override void Use()
    {
        Debug.Log($"Использован предмет: восстановленно здоровье{_healAmount}");
    }


}
