using System;
using UnityEngine;

public class DeathView : MonoBehaviour
{
    private IDiedNotifier _diedNotifier;
   
   [SerializeField] private ParticleSystem _deathEffect;

    private void Start()
    {
        _diedNotifier = GetComponentInParent<IDiedNotifier>();
        _diedNotifier.Died += OnDied;
    }

    private void OnDestroy()
    {
        _diedNotifier.Died -= OnDied;
    }

    private void OnDied()
    {
        Instantiate(_deathEffect, transform.position, Quaternion.identity, null);
    }
}
