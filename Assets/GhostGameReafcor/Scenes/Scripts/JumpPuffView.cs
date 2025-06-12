using UnityEngine;
using System;

public class JumpPuffView : MonoBehaviour
{
    private readonly int JumpKey = Animator.StringToHash("Jump");

    private Animator _animator;
    private IJumper _jumper;

    [SerializeField] private ParticleSystem _jumpEffectPrefab;
    [SerializeField] private Transform _jumpEffectPoint;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _jumper = GetComponentInParent<IJumper>();
        
        if (_jumper != null)
        {
            _jumper.Jumped += OnJumped;
        }
        else
        {
            Debug.LogError("IJumper component not found in parent objects");
        }
    }

    private void OnDestroy()
    {
        if (_jumper != null)
        {
            _jumper.Jumped -= OnJumped;
        }
    }

    private void OnJumped()
    {
        if (_jumpEffectPrefab != null && _jumpEffectPoint != null)
        {
            Instantiate(_jumpEffectPrefab, _jumpEffectPoint.position, Quaternion.identity, null);
        }
        
        if (_animator != null)
        {
            _animator.SetTrigger(JumpKey);
        }
        else
        {
            Debug.LogWarning("Animator component is missing on " + gameObject.name);
        }
    }
}
