using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpeedItem : Items
{
    [SerializeField] private int _boostDuration;
    [SerializeField] private ParticleSystem _DisapearEffect;

    public override int Value => _boostDuration;

    public override void PlayParticleEffect()
    {
        if (_DisapearEffect != null)
        {
            // Создаем партикл-эффект в позиции предмета
            ParticleSystem effect = Instantiate(_DisapearEffect, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration); // Уничтожаем эффект после завершения
        }
    }

    public override void Use()
    {
        Debug.Log($"Использован предмет на ускорение{_boostDuration}");
    }
}
