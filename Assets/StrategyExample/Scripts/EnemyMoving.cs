using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    private float MinDistanceToTarget = 0.05f;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private Transform _currentTarget;



    // //[SerializeField] private List<Transform> _targets;
    // [SerializeField] private Transform _heroTarget;

    // private Queue<Vector3> _targetPosition;
    // private Vector3 _currentTarget;


    

    private void Update()
    {
        Vector3 direction = GetDirectionTo(_currentTarget);

        if(direction.magnitude <= MinDistanceToTarget)
        {
            return;
        }

        Vector3 normalizedDirection = direction.normalized;

        ProcessMoveTo(normalizedDirection);
        ProcessRotateTo(normalizedDirection);
        
    }


    private void ProcessMoveTo(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
        Debug.DrawRay(transform.position, direction, Color.blue);
    }


    private Vector3 GetDirectionTo(Transform target) => target.position - transform.position;


    private void ProcessRotateTo(Vector3 direction)
    {
        Vector3 xzDirection = new Vector3(direction.x, 0, direction.z);

        Quaternion lookRotation = Quaternion.LookRotation(xzDirection);
        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation,step );
    }


    // private Vector3 GetDirectionForHero() => _heroTarget.position - transform.position;

    // private Vector3 GetDirectionToTargetPoint() => _currentTarget - transform.position;



    // private void SwitchTarget()
    // {
    //     _currentTarget = _targetPosition.Dequeue();
    //     _targetPosition.Enqueue(_currentTarget);
    // }



}
