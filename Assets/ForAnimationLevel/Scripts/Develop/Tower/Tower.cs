using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IDirectionRotatable
{
    private TransformDirectionalRotator _rotator;
    [SerializeField]private float _rotationSpeed;

    public Quaternion CurrentRotation => _rotator.CurrentRotation;

    public Vector3 Position => transform.position;

    public void Awake()
    {
        _rotator = new TransformDirectionalRotator(transform, _rotationSpeed);
    }


    private void Update()
    {

        _rotator.Update(Time.deltaTime);

    }


    public void SetRotationDirection(Vector3 inputDirection)=> _rotator.SetInputDirection(inputDirection);

}
