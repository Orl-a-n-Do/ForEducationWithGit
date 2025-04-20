using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarView : MonoBehaviour
{
    [SerializeField] private Transform _leftFrontWheel;
    [SerializeField] private Transform _rightFrontWheel;
    [SerializeField] private Transform _body;

    [SerializeField] private float _maxWheelRotation;
    [SerializeField] private float _maxBodyTilt;


    [SerializeField] private CarEngine _engine;


    [SerializeField] private TrailRenderer _leftWheelTrail;
    [SerializeField] private TrailRenderer _rightWheelTrail;
    [SerializeField] private ParticleSystem _smokeEffect;
    

    private void Update()
    {
        transform.position = _engine.Position - Vector3.up * 0.45f;
        transform.rotation = _engine.CurrentOrientation.rotation;

        _leftFrontWheel.localRotation = Quaternion.Euler(0, _engine.RotationSide * _maxWheelRotation, 0);
        _rightFrontWheel.localRotation = Quaternion.Euler(0, _engine.RotationSide * _maxWheelRotation, 0);

        _body.localRotation = Quaternion.Euler(0, 0, _engine.RotationSide * _maxBodyTilt);

        bool isDrift = _engine.OnGround && _engine.Velocity.magnitude > 3 && Vector3.Angle(_engine.Velocity, transform.forward) > 30f;

        if(isDrift)
        {
            _leftWheelTrail.emitting = true;
            _rightWheelTrail.emitting = true;

            if(_smokeEffect.isPlaying == false)
            {
                _smokeEffect.Play();
            }
        }
        else
        {
            _leftWheelTrail.emitting = false;
            _rightWheelTrail.emitting = false;

            if(_smokeEffect.isPlaying)
            {
                _smokeEffect.Stop();
            }
        }
    }

}
