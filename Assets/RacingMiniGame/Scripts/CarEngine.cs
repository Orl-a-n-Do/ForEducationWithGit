using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    
    [SerializeField]private float _rotationSpeed;
    [SerializeField]private float _speed;
    [SerializeField]private float _maxSpeed;

    [SerializeField] private Rigidbody _movable;
    [SerializeField] private Transform _currentOrientation;

    private float _horizontalInput;
    private float _verticalInput;
    private float _speedInput;

    private bool _onGround;
    public Vector3 Velocity => _movable.velocity;


    public Vector3 Position => _movable.position;
    public Transform CurrentOrientation => _currentOrientation;
    public bool OnGround => _onGround;


    private void Awake()
    {
     _movable.maxLinearVelocity = _maxSpeed;
    }

    private void Update()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        _onGround = Physics.Raycast(_movable.position, Vector3.down, out RaycastHit groundHit, 0.6f);

        if(_onGround)
        {
            Vector3 targetDirection = Vector3.Cross(_currentOrientation.right, groundHit.normal);
            _currentOrientation.rotation = Quaternion.LookRotation(targetDirection);
        }

        _currentOrientation.Rotate(Vector3.up * _horizontalInput * _rotationSpeed * Time.deltaTime, Space.Self);


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;     


        Gizmos.color = Color.blue;
        Physics.Raycast(_movable.position, Vector3.down, out RaycastHit groundHit, 0.6f);
        Gizmos.DrawRay(_movable.position, groundHit.normal);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(_movable.position, Vector3.Cross(_currentOrientation.right, groundHit.normal));

    }


    private void FixedUpdate()
    {
        if(_onGround)
        {
            _movable.AddForce(_currentOrientation.forward * _verticalInput * _speed, ForceMode.Acceleration);

            if(_verticalInput <= 0.05)
            {
                _movable.velocity *= 0.95f;
            }
        }
        else
        {
            _movable.AddForce(_currentOrientation.forward * _speed / 0.5f, ForceMode.Acceleration);
            _movable.AddForce(Vector3.down * 9.81f, ForceMode.Acceleration);
        }

    }




}
