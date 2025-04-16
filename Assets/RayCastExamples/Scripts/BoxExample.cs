using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class BoxExample : MonoBehaviour, IDamageable   
{
    [SerializeField]private ParticleSystem _destroyEffect; //Промежуточный объект, который будет хранить луч от камеры до объекта


    public void TakeDamage(int damage)
    {
        Instantiate(_destroyEffect, transform.position, Quaternion.identity, null); //Создание эффекта разрушения
        Destroy(gameObject); //Уничтожение объекта
    }
}
