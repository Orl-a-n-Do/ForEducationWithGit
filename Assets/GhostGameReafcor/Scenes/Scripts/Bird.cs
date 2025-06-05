using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Vector3 _jumpForce;
    [SerializeField] private ParticleSystem _deathEffect;
    private Rigidbody _rigidbody;

    private int _jumpCount;
    public int JumpCount => _jumpCount;
    private float MaxScale => _defaultScale * 2;

    private float _defaultScale;
    private float _targetScale;
    private float _additiveScalePerJump = 0.25f;


    private void Awake()
    {
        _defaultScale = _targetScale = transform.localScale.x;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        UpdateScale();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(_jumpForce, ForceMode.Impulse);
            _jumpCount++;

            IncreaseScale();
        }
    }

    public void ResetJumpCount()
    {
        _jumpCount = 0;
    }

    public void Kill()
    {
        if (_deathEffect != null)
        {
            _deathEffect.transform.position = transform.position;
            _deathEffect.Play();
        }
        else
        {
            Debug.LogWarning("Death effect is missing or destroyed.");
        }
        gameObject.SetActive(false);
        Debug.Log("Death");
    }

    private void IncreaseScale()
    {
        _targetScale += _additiveScalePerJump;

        if (_targetScale > MaxScale)
        {
            _targetScale = MaxScale;
        }
    }
    
    private void UpdateScale()
    {
        if(_targetScale >_defaultScale)
        {
            _targetScale -= Time.deltaTime;
        }
        transform.localScale = new Vector3(_targetScale, _targetScale, _targetScale);
    }


}
