using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleItem : Items
{

    [SerializeField] private int _invisibleAmount = 5; 
    [SerializeField] private ParticleSystem _InvisibleEffect;

    public override int Value => _invisibleAmount;

    public override void PlayParticleEffect()
    {
        if (_InvisibleEffect != null)
        {
            
            ParticleSystem effect = Instantiate(_InvisibleEffect, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration); 
        }
    }

    public override void Use()
    {
        Debug.Log($"Применена способность невидимки на {_invisibleAmount} ");
    }
}
