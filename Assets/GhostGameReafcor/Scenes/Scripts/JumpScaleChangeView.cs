using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScaleChangeView : MonoBehaviour
{
    private IJumper _jumper;

    private float _defaultScale;
    private float _targetScale;
    private float _additiveScalePerJump = 0.25f;

    private float MaxScale => _defaultScale * 2;


    private void Start()
    {
        _jumper = GetComponentInParent<IJumper>();
        _defaultScale = _targetScale = transform.localScale.x;

        _jumper.Jumped += OnJumped;
    }

    private void OnDestroy()
    {
        _jumper.Jumped -= OnJumped;
    }


    private void Update()
    { 
        UpdateScale();
    }
     

    private void OnJumped()
    {
        IncreaseScale();
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
        if (_targetScale > _defaultScale)
        {
            _targetScale -= Time.deltaTime;
        }
        transform.localScale = new Vector3(_targetScale, _targetScale, _targetScale);
    }
}  
