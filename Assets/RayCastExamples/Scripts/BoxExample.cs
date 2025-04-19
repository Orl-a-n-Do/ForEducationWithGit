using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoxExample : MonoBehaviour, IDamageable, IPickable
{
    [SerializeField]private ParticleSystem _destroyEffect; //Промежуточный объект, который будет хранить луч от камеры до объекта

    private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void TakeDamage(int damage)
    {
        Instantiate(_destroyEffect, transform.position, Quaternion.identity, null); //Создание эффекта разрушения
        Destroy(gameObject); //Уничтожение объекта
    }
}
